using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace CriteriaAssessement
{
    class DAL
    {
        // Объявление строки ConnString
        private static string ConnString
        {
            // Свойство на получение строки подключеня к БД
            get
            {
                // Объявление переменной sb типа SqlConnectionStringBuilder
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                // Присваивание сервера БД как источник данных sb
                sb.DataSource = Properties.Settings.Default.Server;
                // Присваивание БД поумолчанию для sb 
                sb.InitialCatalog = Properties.Settings.Default.DB;
                // Присваивание имени входа для sb
                sb.UserID = Properties.Settings.Default.Login;
                // Присваивание пароля для sb
                sb.Password = Properties.Settings.Default.Password;
                // Возвращение строки подключения
                return sb.ConnectionString;
            }
        }

        public static DataTable SelectTable(string tableName, string id = "0")
        {
            DataTable dt = new DataTable(tableName);
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da;
                    if (tableName == "Экспорт")
                        da = new SqlDataAdapter("SELECT КодСоревнования, Название FROM Соревнование", conn);
                    else if (tableName == "КомпетенцияWS")
                        da = new SqlDataAdapter("SELECT КодКомпетенции, Название FROM КомпетенцияWS ORDER BY КодКомпетенции", conn);
                    else if (tableName == "Раздел")
                        da = new SqlDataAdapter("SELECT КодРазделаWS, Номер, Название, ПроцентЗначимости AS [Процент значимости] FROM РазделWS WHERE КодКомпетенции = '" + id + "' ORDER BY Номер", conn);
                    else if (tableName == "Критерий")
                        da = new SqlDataAdapter("SELECT КодКритерия, Буква, Название FROM Критерий WHERE КодСоревнования = " + Convert.ToInt32(id) + " ORDER BY Буква", conn);
                    else if (tableName == "Подкритерий")
                        da = new SqlDataAdapter("SELECT КодПодкритерия, Буква + CAST(Номер AS varchar) AS [Номер], ПодКритерий.Название, НомерСессии AS [Номер сессии] FROM Подкритерий JOIN Критерий ON Подкритерий.КодКритерия = Критерий.КодКритерия WHERE ПодКритерий.КодКритерия = " + Convert.ToInt32(id) + " ORDER BY Номер", conn);
                    else if (tableName == "Аспект")
                        da = new SqlDataAdapter("SELECT КодАспекта, Номер, Тип, Описание, НомерРаздела AS [Номер радела], МаксимальныйБалл AS [Максимальный балл] FROM Аспект WHERE КодПодкритерия = " + Convert.ToInt32(id) + " ORDER BY Тип DESC, Номер", conn);
                    else if (tableName == "Пояснение")
                        da = new SqlDataAdapter("SELECT КодПояснения, Текст, Оценка FROM Пояснение WHERE КодАспекта = " + Convert.ToInt32(id) + " ORDER BY Оценка", conn);
                    else if (tableName == "Соревнование")
                        da = new SqlDataAdapter("SELECT КодСоревнования, Название, ДатаНачала, ДатаОкончания FROM Соревнование", conn);
                    else if (tableName == "Участник")
                        da = new SqlDataAdapter("SELECT Участник.КодЧеловека, Фамилия, Имя, Отчество, ДатаРождения, Пол, УчебноеЗаведение, НазваниеГруппы, Роль.Название FROM Роль RIGHT JOIN Участник ON Роль.КодРоли = Участник.КодРоли LEFT JOIN Человек ON Участник.КодЧеловека = Человек.КодЧеловека WHERE КодСоревнования = " + Convert.ToInt32(id) + " ORDER BY КодЧеловека", conn);
                    else if (tableName == "Роль")
                        da = new SqlDataAdapter("SELECT КодРоли, Название FROM Роль", conn);
                    else if (tableName == "НомерПодкритерия")
                        da = new SqlDataAdapter("SELECT КодПодкритерия, Буква + CAST(Номер AS varchar) AS [Номер] FROM Подкритерий RIGHT JOIN Критерий ON Подкритерий.КодКритерия = Критерий.КодКритерия WHERE КодСоревнования = " + Convert.ToInt32(id) + " ORDER BY [Номер]", conn);
                    else
                        da = new SqlDataAdapter("SELECT КодСоревнования, Соревнование.Название, ДатаНачала, ДатаОкончания, КомпетенцияWS.КодКомпетенции, " +
                            "КомпетенцияWS.Название FROM Соревнование FULL JOIN КомпетенцияWS ON Соревнование.КодКомпетенции = КомпетенцияWS.КодКомпетенции", conn);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
        }

        /// <summary>
        /// Удаление информации о человеке
        /// </summary>
        /// <param name="idHuman">Код человека</param>
        public static void DeleteMem(int idHuman)
        {
            // Начало блока защищенного кода
            try
            {
                // Использования соединения с БД при помощи строки подключения
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    // Открытие соединения
                    conn.Open();
                    SqlCommand cmd;

                    // Создание поля idHum типа SqlParameter
                    SqlParameter idHum = new SqlParameter
                    {
                        // Присваивание свойству ParameterName значение "@кодЧел"
                        ParameterName = "@кодЧел",
                        // Присваивание свойству SqlDbType значение int
                        SqlDbType = SqlDbType.Int,
                        // Присваивание свойству Value значение idHuman
                        Value = idHuman
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        // Присваивание свойству Direction значение ReturnValue
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    // Создание SQL команды на выполнение удаления информации о человеке
                    cmd = new SqlCommand("DELETE FROM Человек WHERE КодЧеловека = @кодЧел;" +
                        " SET @колИзмен=@@ROWCOUNT", conn);
                    // Добавление параметров в команду
                    cmd.Parameters.Add(idHum);
                    cmd.Parameters.Add(qua);

                    // Выполнение команды
                    cmd.ExecuteNonQuery();

                    // Сравнение возвращаемого значения
                    if (Convert.ToInt32(qua.Value) == 1)
                        // Вывод сообщения на экран
                        MessageBox.Show("Участник удален");
                    else
                        MessageBox.Show("Не удалось удалить участника");
                }
            }
            // Оператор для обработки возникших исключений
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateMembers(int oldId, string surName, string name, string patr, string date, string sex, string inst, string group, int idComp, int idRole, out int id)
        {
            id = oldId;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {

                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter surNam = new SqlParameter
                    {
                        ParameterName = "@фамилия",
                        SqlDbType = SqlDbType.VarChar,
                        Value = surName
                    };

                    SqlParameter nam = new SqlParameter
                    {
                        ParameterName = "@имя",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };

                    SqlParameter pa = new SqlParameter
                    {
                        ParameterName = "@отчество",
                        SqlDbType = SqlDbType.VarChar,
                        Value = patr
                    };

                    SqlParameter dat = new SqlParameter
                    {
                        ParameterName = "@дата",
                        SqlDbType = SqlDbType.Date,
                        Value = date
                    };

                    SqlParameter s = new SqlParameter
                    {
                        ParameterName = "@пол",
                        SqlDbType = SqlDbType.Char,
                        Value = sex
                    };

                    SqlParameter ins = new SqlParameter
                    {
                        ParameterName = "@учЗав",
                        SqlDbType = SqlDbType.VarChar,
                        Value = inst
                    };

                    SqlParameter gr = new SqlParameter
                    {
                        ParameterName = "@группа",
                        SqlDbType = SqlDbType.VarChar,
                        Value = group
                    };

                    SqlParameter idOld = new SqlParameter
                    {
                        ParameterName = "@старыйКод",
                        SqlDbType = SqlDbType.Int,
                        Value = oldId
                    };

                    SqlParameter idCo = new SqlParameter
                    {
                        ParameterName = "@кодСорев",
                        SqlDbType = SqlDbType.Int,
                        Value = idComp
                    };

                    SqlParameter idR = new SqlParameter
                    {
                        ParameterName = "@кодРоли",
                        SqlDbType = SqlDbType.Int,
                        Value = idRole
                    };

                    SqlParameter quaH = new SqlParameter
                    {
                        ParameterName = "@колИзменЧ",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    SqlParameter quaM = new SqlParameter
                    {
                        ParameterName = "@колИзменУ",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    if (oldId != -1)
                    {
                        cmd = new SqlCommand("UPDATE Человек SET Фамилия = @фамилия, Имя = @имя, ", conn);
                        cmd.Parameters.Add(surNam);
                        cmd.Parameters.Add(nam);
                        if (patr != "")
                        {
                            cmd.CommandText += "Отчество = @отчество, ";
                            cmd.Parameters.Add(pa);
                        }
                        else
                            cmd.CommandText += "Отчество = NULL, ";
                        if (date != "")
                        {
                            cmd.CommandText += "ДатаРождения = @дата, ";
                            cmd.Parameters.Add(dat);
                        }
                        else
                            cmd.CommandText += "ДатаРождения = NULL, ";
                        if (sex != "")
                        {
                            cmd.CommandText += "Пол = @пол, ";
                            cmd.Parameters.Add(s);
                        }
                        else
                            cmd.CommandText += "Пол = NULL, ";
                        if (inst != "")
                        {
                            cmd.CommandText += "УчебноеЗаведение = @учЗав, ";
                            cmd.Parameters.Add(ins);
                        }
                        else
                            cmd.CommandText += "УчебноеЗаведение = NULL, ";
                        if (group != "")
                        {
                            cmd.CommandText += "НазваниеГруппы = @группа ";
                            cmd.Parameters.Add(gr);
                        }
                        else
                            cmd.CommandText += "НазваниеГруппы = NULL ";

                        cmd.CommandText += "WHERE КодЧеловека = @старыйКод; SET @колИзменЧ=@@ROWCOUNT; UPDATE Участник SET КодРоли = ";
                        cmd.Parameters.Add(idOld);
                        cmd.Parameters.Add(quaH);
                        if (idRole != -1)
                        {
                            cmd.CommandText += "@кодРоли ";
                            cmd.Parameters.Add(idR);
                        }
                        else
                            cmd.CommandText += "NULL ";
                        cmd.CommandText += "WHERE КодЧеловека = @старыйКод AND КодСоревнования = @кодСорев; SET @колИзменУ=@@ROWCOUNT";
                        cmd.Parameters.Add(idCo);
                        cmd.Parameters.Add(quaM);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO Человек VALUES(@фамилия, @имя, ", conn);
                        cmd.Parameters.Add(surNam);
                        cmd.Parameters.Add(nam);

                        if (patr != "")
                        {
                            cmd.CommandText += "@отчество, ";
                            cmd.Parameters.Add(pa);
                        }
                        else
                            cmd.CommandText += "NULL, ";
                        if (date != "")
                        {
                            cmd.CommandText += "@дата, ";
                            cmd.Parameters.Add(dat);
                        }
                        else
                            cmd.CommandText += "NULL, ";
                        if (sex != "")
                        {
                            cmd.CommandText += "@пол, ";
                            cmd.Parameters.Add(s);
                        }
                        else
                            cmd.CommandText += "NULL, ";
                        if (inst != "")
                        {
                            cmd.CommandText += "@учЗав, ";
                            cmd.Parameters.Add(ins);
                        }
                        else
                            cmd.CommandText += "NULL, ";
                        if (group != "")
                        {
                            cmd.CommandText += "@группа ";
                            cmd.Parameters.Add(gr);
                        }
                        else
                            cmd.CommandText += "NULL ";
                        cmd.CommandText += "); SET @колИзменЧ = @@IDENTITY; INSERT INTO Участник VALUES(@кодСорев, @@IDENTITY, ";
                        cmd.Parameters.Add(quaH);
                        cmd.Parameters.Add(idCo);
                        if (idRole != -1)
                        {
                            cmd.CommandText += "@кодРоли)";
                            cmd.Parameters.Add(idR);
                        }
                        else
                            cmd.CommandText += "NULL)";
                    }
                    cmd.ExecuteNonQuery();

                    if (oldId != -1)
                    {
                        if (Convert.ToInt32(quaH.Value) == 1 && Convert.ToInt32(quaM.Value) == 1)
                        {
                            MessageBox.Show("Информация об участнике изменена");
                        }
                        else if (Convert.ToInt32(quaH.Value) == 1 && Convert.ToInt32(quaM.Value) != 1)
                            MessageBox.Show("Информация о человеке изменена, не уалось именить роль участника");
                        else if (Convert.ToInt32(quaH.Value) != 1 && Convert.ToInt32(quaM.Value) == 1)
                            MessageBox.Show("Роль участника именена изменена, не уалось именить информацию об участнике");
                        else
                            MessageBox.Show("Не удалось изменить информацию об участнике");
                    }
                    else
                    {
                        id = Convert.ToInt32(quaH.Value);
                        MessageBox.Show("Информация об участнике добавлена");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateSkill(string oldId, string newId, string newName, int index, out string id)
        {
            id = oldId;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {

                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter idNew = new SqlParameter
                    {
                        ParameterName = "@новыйКод",
                        SqlDbType = SqlDbType.VarChar,
                        Value = newId
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@новоеНазвание",
                        SqlDbType = SqlDbType.VarChar,
                        Value = newName
                    };

                    SqlParameter idOld = new SqlParameter
                    {
                        ParameterName = "@старыйКод",
                        SqlDbType = SqlDbType.VarChar,
                        Value = oldId
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    if (index != -1)
                    {
                        cmd = new SqlCommand("UPDATE КомпетенцияWS SET КодКомпетенции = @новыйКод, Название = @новоеНазвание " +
                        "WHERE КодКомпетенции = @старыйКод; SET @колИзмен=@@ROWCOUNT UPDATE Соревнование SET КодКомпетенции = @новыйКод " +
                        "WHERE КодКомпетенции = @старыйКод", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO КомпетенцияWS VALUES(@новыйКод, @новоеНазвание)", conn);
                    }

                    cmd.Parameters.Add(idNew);
                    cmd.Parameters.Add(name);
                    if (index != -1)
                        cmd.Parameters.Add(idOld);
                    cmd.Parameters.Add(qua);

                    cmd.ExecuteNonQuery();

                    if (index != -1)
                    {
                        if (Convert.ToInt32(qua.Value) == 1)
                        {
                            MessageBox.Show("Компетенция изменена");
                            id = newId;
                        }
                        else
                            MessageBox.Show("Не удалось изменить компетенцию");
                    }
                    else
                    {
                        id = newId;
                        MessageBox.Show("Компетенция добавлена");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteSkill(string idSkill)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@код",
                        SqlDbType = SqlDbType.VarChar,
                        Value = idSkill
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    cmd = new SqlCommand("DELETE FROM КомпетенцияWS WHERE КодКомпетенции = @код; SET @колИзмен=@@ROWCOUNT", conn);
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(qua);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToInt32(qua.Value) == 1)
                        MessageBox.Show("Компетенция удалена");
                    else
                        MessageBox.Show("Не удалось удалить компетенцию");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateComp(int idComp, string newName, string startDate, string endDate, string idSkill, out int id)
        {
            id = idComp;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter idC = new SqlParameter
                    {
                        ParameterName = "@кодСорев",
                        SqlDbType = SqlDbType.Int,
                        Value = idComp
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@новоеНазвание",
                        SqlDbType = SqlDbType.VarChar,
                        Value = newName
                    };

                    SqlParameter stDate = new SqlParameter
                    {
                        ParameterName = "@новаяДатаНач",
                        SqlDbType = SqlDbType.Date,
                        Value = startDate
                    };

                    SqlParameter enDate = new SqlParameter
                    {
                        ParameterName = "@новаяДатаОконч",
                        SqlDbType = SqlDbType.Date,
                        Value = endDate
                    };

                    SqlParameter idS = new SqlParameter
                    {
                        ParameterName = "@кодКомп",
                        SqlDbType = SqlDbType.VarChar,
                        Value = idSkill
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    if (idComp != 0)
                    {
                        cmd = new SqlCommand("UPDATE Соревнование SET Название = @новоеНазвание, ДатаНачала =  @новаяДатаНач, ДатаОкончания = @новаяДатаОконч", conn);
                        if (idSkill == "")
                            cmd.CommandText += ", КодКомпетенции = NULL ";
                        else
                            cmd.CommandText += ", КодКомпетенции = @кодКомп ";
                        cmd.CommandText += "WHERE КодСоревнования = @кодСорев; SET @колИзмен=@@ROWCOUNT";
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO Соревнование VALUES(@новоеНазвание, @новаяДатаНач, @новаяДатаОконч", conn);
                        if (idSkill != "")
                            cmd.CommandText += ", @кодКомп";
                        else
                            cmd.CommandText += ", NULL";
                        cmd.CommandText += "); SET @колИзмен=@@IDENTITY";
                    }

                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(stDate);
                    cmd.Parameters.Add(enDate);
                    cmd.Parameters.Add(idS);
                    if (idComp != 0)
                        cmd.Parameters.Add(idC);
                    cmd.Parameters.Add(qua);

                    cmd.ExecuteNonQuery();

                    if (idComp != 0)
                    {
                        if (Convert.ToInt32(qua.Value) == 1)
                            MessageBox.Show("Соревнование изменено");
                        else
                            MessageBox.Show("Не удалось изменить соревнование");
                    }
                    else
                    {
                        id = Convert.ToInt32(qua.Value);
                        MessageBox.Show("Соревнование добавлено");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteComp(int idComp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@код",
                        SqlDbType = SqlDbType.VarChar,
                        Value = idComp
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    cmd = new SqlCommand("DELETE FROM Соревнование WHERE КодСоревнования = @код; SET @колИзмен=@@ROWCOUNT", conn);
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(qua);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToInt32(qua.Value) == 1)
                        MessageBox.Show("Соревнование удалено");
                    else
                        MessageBox.Show("Не удалось удалить соревнование");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateSect(int idSkill, DataTable dt, DataTable dtDel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    SqlParameter idSk = new SqlParameter
                    {
                        ParameterName = "@кодКомп",
                        SqlDbType = SqlDbType.VarChar,
                        Value = idSkill
                    };

                    SqlParameter idSec = new SqlParameter
                    {
                        ParameterName = "@кодРазд",
                        SqlDbType = SqlDbType.Int
                    };

                    SqlParameter num = new SqlParameter
                    {
                        ParameterName = "@номер",
                        SqlDbType = SqlDbType.TinyInt
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@название",
                        SqlDbType = SqlDbType.VarChar
                    };

                    SqlParameter imp = new SqlParameter
                    {
                        ParameterName = "@значимость",
                        SqlDbType = SqlDbType.TinyInt
                    };

                    SqlCommand cmdIn = new SqlCommand("INSERT INTO РазделWS VALUES(@кодКомп, @номер, @название, @значимость)", conn);

                    SqlCommand cmdDel = new SqlCommand("DELETE FROM РазделWS WHERE КодРазделаWS = @кодРазд", conn);

                    SqlCommand cmdUpd = new SqlCommand("UPDATE РазделWS SET Номер = @номер, Название = @название, ПроцентЗначимости = @значимость WHERE КодРазделаWS = @кодРазд", conn);

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            num.Value = dr[1];
                            name.Value = dr[2];
                            imp.Value = dr[3];

                            cmdIn.Parameters.Add(idSk);
                            cmdIn.Parameters.Add(num);
                            cmdIn.Parameters.Add(name);
                            cmdIn.Parameters.Add(imp);

                            try
                            {
                                cmdIn.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdIn.Parameters.Clear();
                        }
                        else if (dr.RowState == DataRowState.Modified)
                        {
                            idSec.Value = dr[0];
                            num.Value = dr[1];
                            name.Value = dr[2];
                            imp.Value = dr[3];

                            cmdUpd.Parameters.Add(num);
                            cmdUpd.Parameters.Add(name);
                            cmdUpd.Parameters.Add(imp);
                            cmdUpd.Parameters.Add(idSec);
                            try
                            {
                                cmdUpd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdUpd.Parameters.Clear();
                        }
                    }
                    foreach (DataRow dr in dtDel.Rows)
                    {
                        idSec.Value = dr[0];
                        cmdDel.Parameters.Add(idSec);
                        try
                        {
                            cmdDel.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        cmdDel.Parameters.Clear();
                    }
                    MessageBox.Show("Разделы именены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteSect(int idSkill, int number)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@код",
                        SqlDbType = SqlDbType.VarChar,
                        Value = idSkill
                    };

                    SqlParameter num = new SqlParameter
                    {
                        ParameterName = "@номер",
                        SqlDbType = SqlDbType.TinyInt,
                        Value = number
                    };

                    cmd = new SqlCommand("DELETE FROM РазделWS WHERE КодКомпетенции = @код AND Номер = @номер", conn);
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(num);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateCriteria(int idComp, DataTable dt, DataTable dtDel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    SqlParameter idCom = new SqlParameter
                    {
                        ParameterName = "@кодСорев",
                        SqlDbType = SqlDbType.Int,
                        Value = idComp
                    };

                    SqlParameter idCri = new SqlParameter
                    {
                        ParameterName = "@кодКритерия",
                        SqlDbType = SqlDbType.Int
                    };

                    SqlParameter let = new SqlParameter
                    {
                        ParameterName = "@буква",
                        SqlDbType = SqlDbType.Char
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@название",
                        SqlDbType = SqlDbType.VarChar
                    };

                    SqlCommand cmdIn = new SqlCommand("INSERT INTO Критерий VALUES(@кодСорев, @буква, @название)", conn);

                    SqlCommand cmdDel = new SqlCommand("DELETE FROM Критерий WHERE КодКритерия = @кодКритерия", conn);

                    SqlCommand cmdUpd = new SqlCommand("UPDATE Критерий SET Буква = @буква, Название = @название WHERE КодКритерия = @кодКритерия", conn);

                    foreach (DataRow dr in dtDel.Rows)
                    {
                        idCri.Value = dr[0];
                        cmdDel.Parameters.Add(idCri);
                        try
                        {
                            cmdDel.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        cmdDel.Parameters.Clear();
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            let.Value = dr[1];
                            name.Value = dr[2];

                            cmdIn.Parameters.Add(idCom);
                            cmdIn.Parameters.Add(let);
                            cmdIn.Parameters.Add(name);

                            try
                            {
                                cmdIn.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdIn.Parameters.Clear();
                        }
                        else if (dr.RowState == DataRowState.Modified)
                        {
                            let.Value = dr[1];
                            name.Value = dr[2];

                            idCri.Value = dr[0];
                            cmdUpd.Parameters.Add(let);
                            cmdUpd.Parameters.Add(name);
                            cmdUpd.Parameters.Add(idCri);
                            try
                            {
                                cmdUpd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }

                    MessageBox.Show("Критерии именены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateSubCri(int idCri, DataTable dt, DataTable dtDel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    SqlParameter idC = new SqlParameter
                    {
                        ParameterName = "@кодКритерия",
                        SqlDbType = SqlDbType.Int,
                        Value = idCri
                    };

                    SqlParameter idSC = new SqlParameter
                    {
                        ParameterName = "@кодПодкритерия",
                        SqlDbType = SqlDbType.Int
                    };

                    SqlParameter num = new SqlParameter
                    {
                        ParameterName = "@номер",
                        SqlDbType = SqlDbType.TinyInt
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@название",
                        SqlDbType = SqlDbType.VarChar
                    };

                    SqlParameter numSes = new SqlParameter
                    {
                        ParameterName = "@номерСессии",
                        SqlDbType = SqlDbType.TinyInt
                    };

                    SqlCommand cmdIn = new SqlCommand("INSERT INTO Подкритерий VALUES(@кодКритерия, @номер, @название, @номерСессии)", conn);

                    SqlCommand cmdDel = new SqlCommand("DELETE FROM Подкритерий WHERE КодПодкритерия = @кодПодкритерия", conn);

                    SqlCommand cmdUpd = new SqlCommand("UPDATE Подкритерий SET Номер = @номер, Название = @название, НомерСессии = @номерСессии WHERE КодПодкритерия = @кодПодкритерия", conn);

                    foreach (DataRow dr in dtDel.Rows)
                    {
                        idSC.Value = dr[0];
                        cmdDel.Parameters.Add(idSC);
                        try
                        {
                            cmdDel.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        cmdDel.Parameters.Clear();
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            num.Value = Convert.ToInt32(dr[1].ToString().Substring(1));
                            name.Value = dr[2];
                            numSes.Value = dr[3];

                            cmdIn.Parameters.Add(idC);
                            cmdIn.Parameters.Add(num);
                            cmdIn.Parameters.Add(name);
                            cmdIn.Parameters.Add(numSes);

                            try
                            {
                                cmdIn.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdIn.Parameters.Clear();
                        }
                        else if (dr.RowState == DataRowState.Modified)
                        {
                            idSC.Value = dr[0];
                            num.Value = Convert.ToInt32(dr[1].ToString().Substring(1));
                            name.Value = dr[2];
                            numSes.Value = dr[3];

                            cmdUpd.Parameters.Add(num);
                            cmdUpd.Parameters.Add(name);
                            cmdUpd.Parameters.Add(numSes);
                            cmdUpd.Parameters.Add(idSC);

                            try
                            {
                                cmdUpd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdUpd.Parameters.Clear();
                        }
                    }
                    MessageBox.Show("Подкритерии изменены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateAsp(int idSubCri, DataTable dt, DataTable dtDel, int maxNum)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    SqlParameter idSC = new SqlParameter
                    {
                        ParameterName = "@кодПодкритерия",
                        SqlDbType = SqlDbType.Int,
                        Value = idSubCri
                    };

                    SqlParameter idAsp = new SqlParameter
                    {
                        ParameterName = "@кодАспекта",
                        SqlDbType = SqlDbType.Int
                    };

                    SqlParameter num = new SqlParameter
                    {
                        ParameterName = "@номер",
                        SqlDbType = SqlDbType.TinyInt
                    };

                    SqlParameter type = new SqlParameter
                    {
                        ParameterName = "@тип",
                        SqlDbType = SqlDbType.Char
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@описание",
                        SqlDbType = SqlDbType.VarChar
                    };

                    SqlParameter numSect = new SqlParameter
                    {
                        ParameterName = "@номерРаздела",
                        SqlDbType = SqlDbType.Int
                    };

                    SqlParameter maxMark = new SqlParameter
                    {
                        ParameterName = "@максимальныйБалл",
                        SqlDbType = SqlDbType.Decimal
                    };

                    SqlCommand cmdIn = new SqlCommand("INSERT INTO Аспект VALUES(@кодПодкритерия, @номер, @тип, @описание, @номерРаздела," +
                        " @максимальныйБалл)", conn);

                    SqlCommand cmdDel = new SqlCommand("DELETE FROM Аспект WHERE КодАспекта = @кодАспекта", conn);

                    SqlCommand cmdUpd = new SqlCommand("UPDATE Аспект SET Номер = @номер, Тип = @тип, Описание = @описание, " +
                        "НомерРаздела = @номерРаздела, МаксимальныйБалл = @максимальныйБалл WHERE КодАспекта = @кодАспекта", conn);

                    foreach (DataRow dr in dtDel.Rows)
                    {
                        idAsp.Value = dr[0];
                        cmdDel.Parameters.Add(idAsp);
                        try
                        {
                            cmdDel.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        cmdDel.Parameters.Clear();
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            num.Value = maxNum++;
                            type.Value = dr[2];
                            name.Value = dr[3];
                            numSect.Value = dr[4];
                            maxMark.Value = dr[5];

                            cmdIn.Parameters.Add(idSC);
                            cmdIn.Parameters.Add(num);
                            cmdIn.Parameters.Add(type);
                            cmdIn.Parameters.Add(name);
                            cmdIn.Parameters.Add(numSect);
                            cmdIn.Parameters.Add(maxMark);

                            try
                            {
                                cmdIn.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdIn.Parameters.Clear();
                        }
                        else if (dr.RowState == DataRowState.Modified)
                        {
                            idAsp.Value = dr[0];
                            num.Value = dr[1];
                            type.Value = dr[2];
                            name.Value = dr[3];
                            numSect.Value = dr[4];
                            maxMark.Value = dr[5];

                            cmdUpd.Parameters.Add(num);
                            cmdUpd.Parameters.Add(type);
                            cmdUpd.Parameters.Add(name);
                            cmdUpd.Parameters.Add(numSect);
                            cmdUpd.Parameters.Add(maxMark);
                            cmdUpd.Parameters.Add(idAsp);

                            try
                            {
                                cmdUpd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdUpd.Parameters.Clear();
                        }
                    }

                    UpdateAspNum(idSubCri);

                    MessageBox.Show("Аспекты изменены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateAnnot(int idAspect, DataTable dt, DataTable dtDel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    SqlParameter idAnn = new SqlParameter
                    {
                        ParameterName = "@кодПояснения",
                        SqlDbType = SqlDbType.Int
                    };

                    SqlParameter idAsp = new SqlParameter
                    {
                        ParameterName = "@кодАспекта",
                        SqlDbType = SqlDbType.Int,
                        Value = idAspect
                    };

                    SqlParameter text = new SqlParameter
                    {
                        ParameterName = "@текст",
                        SqlDbType = SqlDbType.VarChar
                    };

                    SqlParameter mark = new SqlParameter
                    {
                        ParameterName = "@оценка",
                        SqlDbType = SqlDbType.TinyInt
                    };

                    SqlCommand cmdIn = new SqlCommand("INSERT INTO Пояснение VALUES(@кодАспекта, @текст, @оценка)", conn);

                    SqlCommand cmdDel = new SqlCommand("DELETE FROM Пояснение WHERE КодПояснения = @кодПояснения", conn);

                    SqlCommand cmdUpd = new SqlCommand("UPDATE Пояснение SET Текст = @текст, Оценка = @оценка WHERE КодПояснения = @кодПояснения", conn);

                    foreach (DataRow dr in dtDel.Rows)
                    {
                        idAnn.Value = dr[0];
                        cmdDel.Parameters.Add(idAnn);
                        try
                        {
                            cmdDel.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        cmdDel.Parameters.Clear();
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            text.Value = dr[1];
                            mark.Value = dr[2];

                            cmdIn.Parameters.Add(idAsp);
                            cmdIn.Parameters.Add(text);
                            cmdIn.Parameters.Add(mark);

                            try
                            {
                                cmdIn.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdIn.Parameters.Clear();
                        }
                        else if (dr.RowState == DataRowState.Modified)
                        {
                            idAnn.Value = dr[0];
                            text.Value = dr[1];
                            mark.Value = dr[2];

                            cmdUpd.Parameters.Add(text);
                            cmdUpd.Parameters.Add(mark);
                            cmdUpd.Parameters.Add(idAnn);

                            try
                            {
                                cmdUpd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            cmdUpd.Parameters.Clear();
                        }
                    }

                    MessageBox.Show("Пояснения к аспектам изменены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SaveComp(int id)
        {
            DataTable dt = new DataTable("Criteria");
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT КомпетенцияWS.Название, Критерий.Буква, Критерий.Название, " +
                            "Подкритерий.Номер AS [Номер подкритерия], Подкритерий.Название AS [Название], Подкритерий.НомерСессии, " +
                            "Аспект.Тип AS [Тип аспекта], Аспект.Описание AS [Описание аспекта], Аспект.Номер, " +
                            "Аспект.НомерРаздела,  Аспект.МаксимальныйБалл AS [Максимальный балл], Пояснение.Оценка, Пояснение.Текст FROM РазделWS " +
                            "RIGHT JOIN КомпетенцияWS ON РазделWS.КодКомпетенции = КомпетенцияWS.КодКомпетенции " +
                            "RIGHT JOIN Соревнование ON КомпетенцияWS.КодКомпетенции = Соревнование.КодКомпетенции LEFT JOIN Критерий ON Соревнование.КодСоревнования = Критерий.КодСоревнования " +
                            "LEFT JOIN Подкритерий ON Критерий.КодКритерия = Подкритерий.КодКритерия LEFT JOIN Аспект ON Подкритерий.КодПодкритерия = Аспект.КодПодкритерия " +
                            "LEFT JOIN Пояснение ON Аспект.КодАспекта = Пояснение.КодАспекта WHERE Соревнование.КодСоревнования = " + id + " " +
                            "Order by Критерий.Буква, [Номер подкритерия], Аспект.Номер", conn);
                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            dt.Columns.Clear();
                            da.SelectCommand.CommandText = "SELECT DISTINCTКритерий.Буква, Критерий.Название, " +
                            "Подкритерий.Номер AS [Номер подкритерия], Подкритерий.Название AS [Название], Подкритерий.НомерСессии, " +
                            "Аспект.Тип AS [Тип аспекта], Аспект.Описание AS [Описание аспекта], Аспект.Номер, " +
                            "Аспект.МаксимальныйБалл AS [Максимальный балл], Пояснение.Оценка, Пояснение.Текст FROM " +
                            "Соревнование LEFT JOIN Критерий ON Соревнование.КодСоревнования = Критерий.КодСоревнования " +
                            "LEFT JOIN Подкритерий ON Критерий.КодКритерия = Подкритерий.КодКритерия LEFT JOIN Аспект ON Подкритерий.КодПодкритерия = Аспект.КодПодкритерия " +
                            "LEFT JOIN Пояснение ON Аспект.КодАспекта = Пояснение.КодАспекта WHERE Соревнование.КодСоревнования = " + id + " " +
                            "Order by Критерий.Буква, [Номер подкритерия], Аспект.Номер, Пояснение.Оценка";
                            da.Fill(dt);
                            dt.Columns.Add("1").SetOrdinal(0);
                            dt.Columns.Add("2").SetOrdinal(9);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string fileName = "";
            Excel.Application app = new Excel.Application();
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "*.xlsx;*.csv";
                sfd.Filter = " Excel 2007(*.xlsx)|*.xlsx|CSV(*.csv)|*.csv";
                sfd.Title = "Выберите документ для выгрузки данных";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    fileName = sfd.FileName;
                    Excel.Workbook workbook;
                    Excel.Worksheet worksheet;
                    workbook = app.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                    worksheet.Columns.Clear();
                    Excel.Range excelRange;
                    int row = 1;

                    excelRange = (Excel.Range)worksheet.Cells[row++, 4];
                    excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelRange.Value2 = "Skill name";

                    excelRange = (Excel.Range)worksheet.Cells[row++, 4];
                    excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelRange.Value2 = dt.Rows[0][0].ToString();

                    excelRange = (Excel.Range)worksheet.Cells[row, 4];
                    excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelRange.Value2 = "Criteria";

                    excelRange = (Excel.Range)worksheet.Cells[row++, 5];
                    excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelRange.Value2 = "Mark";

                    double sum = 0;
                    var someList = new SortedList<string, double>();
                    var nameList = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][1].ToString() != DBNull.Value.ToString())
                            if (!someList.ContainsKey(dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString()))
                            {
                                someList.Add(dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString(), dt.Rows[i][10].ToString() != DBNull.Value.ToString() ? Convert.ToDouble(dt.Rows[i][10]) : 0);
                                nameList.Add(dt.Rows[i][3].ToString() + dt.Rows[i][6].ToString() + dt.Rows[i][7].ToString() + dt.Rows[i][8].ToString());
                            }
                            else if (dt.Rows[i][10].ToString() != DBNull.Value.ToString() && someList.ContainsKey(dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString()) && !nameList.Contains(dt.Rows[i][3].ToString() + dt.Rows[i][6].ToString() + dt.Rows[i][7].ToString() + dt.Rows[i][8].ToString()))
                            {
                                sum = someList.Values[someList.IndexOfKey(dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString())];
                                sum += Convert.ToDouble(dt.Rows[i][10]);
                                someList.Remove(dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString());
                                someList.Add(dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString(), sum);
                                nameList.Add(dt.Rows[i][3].ToString() + dt.Rows[i][6].ToString() + dt.Rows[i][7].ToString() + dt.Rows[i][8].ToString());
                            }
                    }

                    for (int i = 0, ro = 4; i < someList.Count; i++)
                    {
                        excelRange = (Excel.Range)worksheet.Cells[ro, 3];
                        excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelRange.Value2 = someList.Keys[i].Substring(0, 1);
                        excelRange = (Excel.Range)worksheet.Cells[ro, 4];
                        excelRange.Value2 = someList.Keys[i].Substring(1);
                        excelRange = (Excel.Range)worksheet.Cells[ro++, 5];
                        excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelRange.Value2 = someList.Values[i];
                    }

                    string[] head = new string[] { "Sub\nCriteria\nID", "Sub Criteria\n\nName or Description", "Aspect\nType\nO = Obj\nJ = Judg",
                        "Aspect - Description", "Judg Score", "Extra Aspect Description (Obj or Subj)\nOR\nJudgement Score Description (Judg only)",
                        "Requirement\nor Nominal\nSize (Obj Only)", "WSSS Section", "Max\nMark"};

                    row = 13;
                    int ii = 0;
                    int k = 0;
                    string letter;
                    try
                    {
                        letter = dt.Rows[ii - 1][1].ToString();
                    }
                    catch
                    {
                        letter = "QWE";
                    }
                    while (ii < dt.Rows.Count)
                    {
                        int jj = 3;
                        int col = 1;
                        string idCri = dt.Rows[ii][jj++].ToString();

                        if (dt.Rows[ii][1].ToString() != letter)
                        {
                            row += 2;
                            for (int i = 0; i < head.Count(); i++)
                            {
                                excelRange = (Excel.Range)worksheet.Cells[row, i + 1];
                                excelRange.Style.Font.Size = 10;
                                excelRange.Style.Font.Name = "Arial";
                                excelRange.Interior.Color = Excel.XlRgbColor.rgbDarkGrey;
                                excelRange.Font.Color = Excel.XlRgbColor.rgbWhite;
                                excelRange.WrapText = true;
                                excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                                excelRange.VerticalAlignment = Excel.Constants.xlCenter;
                                excelRange.Value2 = head[i];
                            }

                            letter = dt.Rows[ii][1].ToString();

                            if (someList.Count > 0)
                            {
                                excelRange = (Excel.Range)worksheet.Cells[row, 10];
                                excelRange.Value2 = "Criterion " + someList.Keys[k].Substring(0, 1);

                                excelRange = (Excel.Range)worksheet.Cells[row, 11];
                                excelRange.Value2 = "Total\nMark";

                                excelRange = (Excel.Range)worksheet.Cells[row, 12];
                                excelRange.Value2 = someList.Values[k];

                                excelRange = (Excel.Range)worksheet.Range[worksheet.Cells[row, 10], worksheet.Cells[row, 12]];
                                excelRange.WrapText = true;
                                excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                                excelRange.VerticalAlignment = Excel.Constants.xlCenter;
                                k++;
                                row++;
                            }

                        }
                        if (dt.Rows.Count == 1 && dt.Rows[0][1].ToString() == "" || dt.Rows[ii][2].ToString() == "")
                        {
                            ii++;
                            continue;
                        }
                        excelRange = (Excel.Range)worksheet.Cells[row, col++];
                        excelRange.Value2 = dt.Rows[ii][1].ToString() + idCri;
                        excelRange = (Excel.Range)worksheet.Cells[row++, col++];
                        excelRange.Value2 = dt.Rows[ii][jj++].ToString();
                        if (dt.Rows[ii][jj].ToString() != "")
                        {
                            if (dt.Rows[ii][jj].ToString() != "0")
                                excelRange.Value2 += " - сессия " + dt.Rows[ii][jj++].ToString();
                            else
                                excelRange.Value2 += " - все сессии";
                        }
                        while (ii < dt.Rows.Count && letter == dt.Rows[ii][1].ToString() && dt.Rows[ii][3].ToString() == idCri)
                        {
                            excelRange = (Excel.Range)worksheet.Cells[row, col++];
                            excelRange.Value2 = dt.Rows[ii][6].ToString();
                            excelRange = (Excel.Range)worksheet.Cells[row, col++];
                            excelRange.Value2 = dt.Rows[ii][7].ToString();
                            excelRange = (Excel.Range)worksheet.Cells[row, col + 3];
                            excelRange.Value2 = dt.Rows[ii][9].ToString();
                            if (dt.Rows[ii][10].ToString() != DBNull.Value.ToString())
                            {
                                excelRange = (Excel.Range)worksheet.Cells[row, col + 4];
                                excelRange.Value2 = Convert.ToDouble(dt.Rows[ii][10]);
                            }
                            if (dt.Rows[ii][6].ToString() != DBNull.Value.ToString())
                            {
                                char typeAsp = Convert.ToChar(dt.Rows[ii][6]);
                                if (typeAsp == 'J')
                                    row++;
                                int idAsp = Convert.ToInt32(dt.Rows[ii][8]);
                                int numCri = Convert.ToInt32(dt.Rows[ii][3]);
                                while (ii < dt.Rows.Count && dt.Rows[ii][8].ToString() != DBNull.Value.ToString()
                                    && Convert.ToInt32(dt.Rows[ii][8]) == idAsp && typeAsp == Convert.ToChar(dt.Rows[ii][6]) && numCri == Convert.ToInt32(dt.Rows[ii][3]))
                                {
                                    if (dt.Rows[ii][11].ToString() != DBNull.Value.ToString())
                                    {
                                        excelRange = (Excel.Range)worksheet.Cells[row, col++];
                                        excelRange.Value2 = dt.Rows[ii][11].ToString();
                                    }
                                    if (dt.Rows[ii][12].ToString() != DBNull.Value.ToString())
                                    {
                                        if (dt.Rows[ii][6].ToString() == "O")
                                            col++;
                                        excelRange = (Excel.Range)worksheet.Cells[row, col];
                                        excelRange.Value2 = dt.Rows[ii][12].ToString();
                                    }
                                    col = 5;
                                    row++;
                                    ii++;
                                }
                            }
                            else
                                ii++;
                            col = 3;
                        }
                    }
                    row += 2;

                    excelRange = (Excel.Range)worksheet.Cells[row + 2, 10];
                    excelRange.Value2 = "Competition";

                    excelRange = (Excel.Range)worksheet.Cells[row + 2, 11];
                    excelRange.Value2 = "Total\nMark";

                    double mark = 0;
                    for (int i = 0; i < someList.Count; i++)
                        mark += someList.Values[i];

                    excelRange = (Excel.Range)worksheet.Cells[row + 2, 12];
                    excelRange.Value2 = mark;

                    excelRange = worksheet.Range[(Excel.Range)worksheet.Cells[row + 2, 10], (Excel.Range)worksheet.Cells[row + 2, 12]];
                    excelRange.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelRange.VerticalAlignment = Excel.Constants.xlCenter;


                    int[] width = new int[] { 7, 26, 7, 35, 6, 34, 12, 10, 6, 14, 7, 8 };
                    for (int i = 0; i < width.Length; i++)
                    {
                        excelRange = (Excel.Range)worksheet.Cells[1, i + 1];
                        excelRange.ColumnWidth = width[i];
                    }

                    excelRange = (Excel.Range)worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[row - 1, 9]];
                    excelRange.Style.Font.Name = "Arial";
                    excelRange.Style.Font.Size = 10;
                    excelRange = (Excel.Range)worksheet.Range[worksheet.Cells[15, 1], worksheet.Cells[row - 1, 9]];
                    excelRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                    app.AlertBeforeOverwriting = true;
                    if (Path.GetExtension(sfd.FileName) == ".csv")
                        worksheet.SaveAs(sfd.FileName, Excel.XlFileFormat.xlCSVWindows);
                    else
                        worksheet.SaveAs(sfd.FileName);
                    app.Quit();

                }
                else
                {
                    app.Quit();
                    return;
                }
                if (Path.GetExtension(fileName) == ".csv")
                {
                    string[] oldInfo = File.ReadAllLines(fileName, Encoding.GetEncoding(1251));
                    List<string> newInfo = new List<string>() { "sep=," };
                    File.WriteAllLines(fileName, newInfo.Concat(oldInfo), Encoding.GetEncoding(1251));
                }
                MessageBox.Show("Схема оценивания успешно сохранена в файл");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Редактирование файла запрещено/вы отменили сохранение файла");
                app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                app.Quit();
            }
        }

        /// <summary>
        /// Импорт информации в БД из файла формата *.xlsx или *.csv
        /// </summary>
        /// <param name="idComp">Код соревнования</param>
        /// <param name="nameSkill">Название компетенции</param>
        /// <returns>Возвращает объект типа DataTable</returns>
        public static DataTable ImportSkill(int idComp, string nameSkill)
        {
            DataTable dt = new DataTable();
            Excel.Application app = new Excel.Application();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xlsx";
            // Указание допустимых расширений файла
            ofd.Filter = " Excel 2007(*.xlsx)|*.xlsx|CSV(*.csv)|*.csv";
            ofd.Title = "Выберите документ для загрузки данных";
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Excel.Workbook workbook;
                    Excel.Worksheet worksheet;
                    // Открытие электронной книги и выбор листа
                    workbook = app.Workbooks.Open(ofd.FileName);
                    worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);

                    // Сохранение информации о последней ячейке в переменную
                    var lastCell = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                    for (int i = 0; i < lastCell.Column; i++)
                        dt.Columns.Add();
                    for (int rowCount = 0; rowCount < lastCell.Row; rowCount++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int colCount = 0; colCount < lastCell.Column; colCount++)
                            if (((Excel.Range)worksheet.Cells[rowCount + 1, colCount + 1]).Value != null)
                                dr[colCount] = ((Excel.Range)worksheet.Cells[rowCount + 1, colCount + 1]).Value;
                        dt.Rows.Add(dr);
                    }

                    if (dt.Rows[0][3].ToString() == "Skill name" && (dt.Rows[1][3].ToString() == nameSkill || nameSkill == ""))
                    {
                        if (dt.Rows[2][3].ToString() == "Criteria" && dt.Rows[2][4].ToString() == "Mark")
                        {
                            int row = 3;
                            List<int> idCompetence = new List<int>();
                            int id;

                            while (dt.Rows[row][2].ToString() != "" && dt.Rows[row][3].ToString() != "" && dt.Rows[row][4].ToString() != "")
                            {
                                // Вызов метода на добавление критерия
                                id = InsertCrit(idComp, Convert.ToChar(dt.Rows[row][2]), dt.Rows[row++][3].ToString());
                                if (id != -1)
                                    idCompetence.Add(id);
                            }

                            row = 14;
                            int k = 0;
                            string[] nameSC;

                            while (dt.Rows[row++][0].ToString() == "Sub\nCriteria\nID")
                            {
                                while (row < lastCell.Row - 3 && dt.Rows[row][0].ToString() != "Sub\nCriteria\nID" && k < idCompetence.Count)
                                {
                                    nameSC = dt.Rows[row][1].ToString().Split('-');
                                    if (nameSC.Count() > 1)
                                    {
                                        // Вызов метода на добавление подкритерия
                                        id = InsertSubCri(idCompetence[k], Convert.ToInt32(dt.Rows[row][0].ToString().Substring(1)),
                                            nameSC[0].Trim(), nameSC[1].Trim() == "все сессии" ? 0 : Convert.ToInt32(nameSC[1].Trim().Substring(nameSC[1].Trim().Length - 1, 1)));
                                        row++;
                                        List<int> asNum = AspectNumbers(id);
                                        if (id != -1 && asNum != null)
                                        {
                                            int l = 1;
                                            while (row < lastCell.Row - 3 && dt.Rows[row][0].ToString() == "" && dt.Rows[row][3].ToString() != "")
                                            {
                                                if (dt.Rows[row][2].ToString() != "")
                                                {
                                                    int idAs;
                                                    // Вызов метода на добавление аспекта
                                                    idAs = InsertAsp(id, l, dt.Rows[row][2].ToString(),
                                                        dt.Rows[row][3].ToString(), dt.Rows[row][7].ToString() != "" ? Convert.ToInt32(dt.Rows[row][7]) : -1,
                                                        dt.Rows[row][8].ToString() != "" ? Convert.ToDouble(dt.Rows[row][8]) : 0);
                                                    if (idAs == -1)
                                                    {
                                                        row++;
                                                        continue;
                                                    }
                                                    if (dt.Rows[row][5].ToString() != "" && dt.Rows[row][2].ToString() == "O")
                                                        // Вызов метода на добавление пояснения
                                                        InsertCom(idAs, dt.Rows[row][5].ToString(), "-1");
                                                    row++;
                                                    while (row < lastCell.Row - 3 && dt.Rows[row][0].ToString() == "" && dt.Rows[row][2].ToString() == "" && dt.Rows[row][5].ToString() != "")
                                                    {
                                                        // Вызов метода на добавление пояснения
                                                        InsertCom(idAs, dt.Rows[row][5].ToString(), dt.Rows[row][4].ToString() != "" ? dt.Rows[row][4].ToString() : "-1");
                                                        row++;
                                                    }
                                                    l++;
                                                }
                                                else
                                                    row++;
                                            }
                                            UpdateAspNum(id);
                                            asNum.Clear();
                                        }
                                    }
                                    else
                                        row++;
                                }
                                k++;
                            }

                            MessageBox.Show("Схема оценивания успешно сохранена в базу данных");
                        }
                        else
                            MessageBox.Show("Структура файла не соответствует требуемой");
                    }
                    else
                        MessageBox.Show("Компетенция в файле отличается от компитенции соревнования");
                }
                app.Quit();
            }
            catch (Exception ex)
            {
                app.Quit();
                MessageBox.Show(ex.Message);
                return null;
            }
            return dt;
        }

        private static void UpdateAspNum(int id)
        {
            DataTable dt = SelectTable("Аспект", id.ToString());
            int r = 0;
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlParameter newNum = new SqlParameter
                {
                    ParameterName = "@номер",
                    SqlDbType = SqlDbType.TinyInt,
                    Value = 1
                };

                SqlParameter idA = new SqlParameter
                {
                    ParameterName = "@код",
                    SqlDbType = SqlDbType.Int
                };
                SqlCommand sqlC = new SqlCommand("UPDATE Аспект SET Номер = @номер WHERE КодАспекта = @код", conn);
                while (dt.Rows.Count >= r + 1 && dt.Rows[r][2].ToString() == "O")
                {
                    idA.Value = Convert.ToInt32(dt.Rows[r][0]);
                    try
                    {
                        sqlC.Parameters.Add(newNum);
                        sqlC.Parameters.Add(idA);
                        sqlC.ExecuteNonQuery();
                        newNum.Value = Convert.ToInt32(newNum.Value) + 1;
                        sqlC.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    r++;
                }

                newNum.Value = 1;
                while (dt.Rows.Count >= r + 1 && dt.Rows[r][2].ToString() == "J")
                {
                    idA.Value = Convert.ToInt32(dt.Rows[r][0]);
                    try
                    {
                        sqlC.Parameters.Add(newNum);
                        sqlC.Parameters.Add(idA);
                        sqlC.ExecuteNonQuery();
                        newNum.Value = Convert.ToInt32(newNum.Value) + 1;
                        sqlC.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    r++;
                }
            }
        }

        private static void InsertCom(int idAsp, string text, string mark)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter idA = new SqlParameter
                    {
                        ParameterName = "@кодАсп",
                        SqlDbType = SqlDbType.Int,
                        Value = idAsp
                    };

                    SqlParameter tex = new SqlParameter
                    {
                        ParameterName = "@текст",
                        SqlDbType = SqlDbType.VarChar,
                        Value = text
                    };

                    SqlParameter mar = new SqlParameter
                    {
                        ParameterName = "@оценка",
                        SqlDbType = SqlDbType.Int,
                        Value = Convert.ToInt32(mark)
                    };


                    cmd = new SqlCommand("INSERT INTO Пояснение VALUES(@кодАсп, @текст, ", conn);

                    if (new[] { "0", "1", "2", "3" }.Contains(mark))
                        cmd.CommandText += "@оценка)";
                    else
                        cmd.CommandText += "NULL)";

                    cmd.Parameters.Add(idA);
                    cmd.Parameters.Add(tex);
                    if (new[] { "0", "1", "2", "3" }.Contains(mark))
                        cmd.Parameters.Add(mar);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { }
        }

        private static int InsertAsp(int idSC, int number, string type, string descript, int numSect, double maxMark)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;
                    try
                    {
                        int id;
                        id = FindAsp(idSC, type, descript);
                        if (id != -1)
                            return id;
                        else
                        {
                            SqlParameter idSc = new SqlParameter
                            {
                                ParameterName = "@кодПодкр",
                                SqlDbType = SqlDbType.Int,
                                Value = idSC
                            };

                            SqlParameter num = new SqlParameter
                            {
                                ParameterName = "@номер",
                                SqlDbType = SqlDbType.Int,
                                Value = number
                            };

                            SqlParameter typ = new SqlParameter
                            {
                                ParameterName = "@тип",
                                SqlDbType = SqlDbType.Char,
                                Value = Convert.ToChar(type)
                            };

                            SqlParameter desc = new SqlParameter
                            {
                                ParameterName = "@описание",
                                SqlDbType = SqlDbType.VarChar,
                                Value = descript
                            };

                            SqlParameter numS = new SqlParameter
                            {
                                ParameterName = "@номерСекции",
                                SqlDbType = SqlDbType.Int,
                                Value = numSect
                            };

                            SqlParameter maxM = new SqlParameter
                            {
                                ParameterName = "@максОценка",
                                SqlDbType = SqlDbType.Decimal,
                                Value = maxMark
                            };

                            SqlParameter qua = new SqlParameter
                            {
                                ParameterName = "@колИзмен",
                                Direction = ParameterDirection.Output,
                                SqlDbType = SqlDbType.Int
                            };

                            cmd = new SqlCommand("INSERT INTO Аспект VALUES(@кодПодкр, @номер, @тип, @описание, ", conn);

                            if (numSect != -1)
                                cmd.CommandText += "@номерСекции,";
                            else
                                cmd.CommandText += "NULL, ";
                            cmd.CommandText += "@максОценка); SET @колИзмен = @@IDENTITY";

                            cmd.Parameters.Add(idSc);
                            cmd.Parameters.Add(num);
                            cmd.Parameters.Add(typ);
                            cmd.Parameters.Add(desc);
                            if (numSect != -1)
                                cmd.Parameters.Add(numS);
                            cmd.Parameters.Add(maxM);
                            cmd.Parameters.Add(qua);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                return Convert.ToInt32(qua.Value);
                            }
                            catch
                            {
                                return -1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return -1;
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неверный тип аспекта " + type);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private static int FindAsp(int id, string type, string desc)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter idSC = new SqlParameter
                    {
                        ParameterName = "@кодПодкр",
                        SqlDbType = SqlDbType.Int,
                        Value = id
                    };

                    SqlParameter typ = new SqlParameter
                    {
                        ParameterName = "@тип",
                        SqlDbType = SqlDbType.Char,
                        Value = type
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@описание",
                        SqlDbType = SqlDbType.VarChar,
                        Value = desc
                    };

                    cmd = new SqlCommand("SELECT КодАспекта FROM Аспект WHERE КодПодкритерия = @кодПодкр AND Тип = @тип AND Описание = @описание", conn);

                    cmd.Parameters.Add(idSC);
                    cmd.Parameters.Add(typ);
                    cmd.Parameters.Add(name);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int InsertCrit(int idComp, char letter, string nameCrit)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter idC = new SqlParameter
                    {
                        ParameterName = "@кодСорев",
                        SqlDbType = SqlDbType.Int,
                        Value = idComp
                    };

                    SqlParameter let = new SqlParameter
                    {
                        ParameterName = "@буква",
                        SqlDbType = SqlDbType.Char,
                        Value = letter
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@название",
                        SqlDbType = SqlDbType.VarChar,
                        Value = nameCrit
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    cmd = new SqlCommand("SELECT КодКритерия FROM Критерий WHERE КодСоревнования = @кодСорев AND Буква = @буква", conn);
                    cmd.Parameters.Add(idC);
                    cmd.Parameters.Add(let);
                    int id;
                    id = Convert.ToInt32(cmd.ExecuteScalar());

                    if (id != 0)
                    {
                        MessageBox.Show("Запись с критерием \"" + nameCrit + "\" у данного соревнования уже существует");
                        return id;
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("INSERT INTO Критерий VALUES(@кодСорев, @буква, @название); SET @колИзмен = @@IDENTITY", conn);

                        try
                        {
                            cmd.Parameters.Add(idC);
                            cmd.Parameters.Add(let);
                            cmd.Parameters.Add(name);
                            cmd.Parameters.Add(qua);

                            cmd.ExecuteNonQuery();

                            return Convert.ToInt32(qua.Value);
                        }
                        catch (Exception ex)
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public static int InsertSubCri(int idCri, int numberSC, string nameSC, int numberSes)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter idC = new SqlParameter
                    {
                        ParameterName = "@кодКритерия",
                        SqlDbType = SqlDbType.Int,
                        Value = idCri
                    };

                    SqlParameter number = new SqlParameter
                    {
                        ParameterName = "@номер",
                        SqlDbType = SqlDbType.Int,
                        Value = numberSC
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@название",
                        SqlDbType = SqlDbType.VarChar,
                        Value = nameSC
                    };

                    SqlParameter numberS = new SqlParameter
                    {
                        ParameterName = "@номерСессии",
                        SqlDbType = SqlDbType.Int,
                        Value = numberSes
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    cmd = new SqlCommand("SELECT КодПодкритерия FROM Подкритерий WHERE КодКритерия = @кодКритерия AND Номер = @номер", conn);
                    cmd.Parameters.Add(idC);
                    cmd.Parameters.Add(number);
                    int id;
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    if (id != 0)
                    {
                        MessageBox.Show("Запись с подкритерием \"" + nameSC + "\" уже существует");
                        return id;
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("INSERT INTO Подкритерий VALUES(@кодКритерия, @номер, @название, @номерСессии); SET @колИзмен = @@IDENTITY", conn);

                        try
                        {
                            cmd.Parameters.Add(idC);
                            cmd.Parameters.Add(number);
                            cmd.Parameters.Add(name);
                            cmd.Parameters.Add(numberS);
                            cmd.Parameters.Add(qua);

                            cmd.ExecuteNonQuery();

                            return Convert.ToInt32(qua.Value);
                        }
                        catch (Exception ex)
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public static List<int> AspectNumbers(int idSubCri)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter idSC = new SqlParameter
                    {
                        ParameterName = "@кодПодкритерия",
                        SqlDbType = SqlDbType.Int,
                        Value = idSubCri
                    };
                    cmd = new SqlCommand("SELECT Номер FROM Аспект WHERE КодПодкритерия = @кодПодкритерия", conn);

                    cmd.Parameters.Add(idSC);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<int> asNum = new List<int>();
                    int count = 0;
                    while (dr.Read())
                    {
                        asNum.Add(Convert.ToInt32(((IDataRecord)dr)[0]));
                        count++;
                    }
                    return asNum;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void SaveMem(int idComp)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Фамилия, Имя, Отчество, ДатаРождения AS [Дата рождения], Пол, Название AS Роль " +
                        "FROM Человек RIGHT JOIN Участник ON Человек.КодЧеловека = Участник.КодЧеловека " +
                        "LEFT JOIN Роль ON Участник.КодРоли = Роль.КодРоли WHERE КодСоревнования = " + idComp, conn);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "*.xlsx";
                sfd.Filter = " Excel 2007(*.xlsx)|*.xlsx|csv|*.csv";
                sfd.Title = "Выберите документ для выгрузки данных";
                string fileName;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application app = new Excel.Application();
                    try
                    {
                        Excel.Workbook workbook;
                        Excel.Worksheet worksheet;
                        workbook = app.Workbooks.Add();
                        worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                        worksheet.Columns.Clear();
                        Excel.Range excelRange;
                        fileName = sfd.FileName;

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            excelRange = (Excel.Range)worksheet.Cells[1, i + 1];
                            excelRange.Value2 = dt.Columns[i].Caption;
                        }

                        for (int row = 0; row < dt.Rows.Count; row++)
                            for (int col = 0; col < dt.Columns.Count; col++)
                            {
                                excelRange = (Excel.Range)worksheet.Cells[row + 2, col + 1];
                                if (col == 3)
                                    excelRange.NumberFormat = "dd.MM.yyyy";
                                excelRange.Value2 = dt.Rows[row][col];
                            }
                        if (Path.GetExtension(fileName) == ".csv")
                            worksheet.SaveAs(sfd.FileName, Excel.XlFileFormat.xlCSVWindows);
                        else
                            worksheet.SaveAs(sfd.FileName);
                        app.Quit();
                        MessageBox.Show("Информация об участниках успешно сохранена в файл");
                    }
                    catch (System.Runtime.InteropServices.COMException ex)
                    {
                        MessageBox.Show("Редактирование файла запрещено/вы отменили сохранение файла");
                        app.Quit();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        app.Quit();
                        return;
                    }
                    app.Quit();
                }
                else
                    return;
                if (Path.GetExtension(fileName) == ".csv")
                {
                    string[] oldInfo = File.ReadAllLines(fileName, Encoding.GetEncoding(1251));
                    List<string> newInfo = new List<string>() { "sep=," };
                    File.WriteAllLines(fileName, newInfo.Concat(oldInfo), Encoding.GetEncoding(1251));
                }
            }
        }

        public static void ImportMem(int idComp)
        {
            DataTable dt = new DataTable();
            Excel.Application app = new Excel.Application();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xlsx";
            ofd.Filter = " Excel 2007(*.xlsx)|*.xlsx|csv(*.csv)|*.csv";
            ofd.Title = "Выберите документ для загрузки данных";
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<string> head = new List<string>()
                    {
                        "Фамилия","Имя","Отчество","Дата рождения","Пол","Роль"
                    };

                    Excel.Workbook workbook;
                    Excel.Worksheet worksheet;
                    workbook = app.Workbooks.Open(ofd.FileName);
                    worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);

                    var lastCell = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                    for (int i = 0; i < lastCell.Column; i++)
                        if (((Excel.Range)worksheet.Cells[1, i + 1]).Value == head[i])
                            dt.Columns.Add();
                        else
                        {
                            MessageBox.Show("Столбцы в файле не совпадают с требуемыми");
                            return;
                        }
                    for (int rowCount = 0; rowCount < lastCell.Row - 1; rowCount++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int colCount = 0; colCount < lastCell.Column; colCount++)
                            if (((Excel.Range)worksheet.Cells[rowCount + 2, colCount + 1]).Value != null)
                                dr[colCount] = ((Excel.Range)worksheet.Cells[rowCount + 2, colCount + 1]).Value;
                        dt.Rows.Add(dr);
                    }

                    int idHum;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Path.GetExtension(ofd.FileName) == ".csv")
                            idHum = AddHum(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), true);
                        else
                            idHum = AddHum(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), false);
                        if (idHum != -1)
                            AddMem(idComp, idHum, dr[5].ToString() != "" ? AddRole(dr[5].ToString()) : -1);
                    }
                    MessageBox.Show("Информация об участниках успешно добавлена в базу данных");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                app.Quit();
                return;
            }
            app.Quit();
        }

        private static void AddMem(int idC, int idH, int idR)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter comp = new SqlParameter
                    {
                        ParameterName = "@кодСорев",
                        SqlDbType = SqlDbType.Int,
                        Value = idC
                    };

                    SqlParameter hum = new SqlParameter
                    {
                        ParameterName = "@кодЧел",
                        SqlDbType = SqlDbType.Int,
                        Value = idH
                    };

                    SqlParameter role = new SqlParameter
                    {
                        ParameterName = "@кодРоли",
                        SqlDbType = SqlDbType.Int,
                        Value = idR
                    };


                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    cmd = new SqlCommand("INSERT INTO Участник VALUES(@кодСорев, @кодЧел, ", conn);
                    if (idR == -1)
                        cmd.CommandText += "NULL";
                    else
                        cmd.CommandText += "@кодРоли";
                    cmd.CommandText += "); SET @колИзмен = @@ROWCOUNT";
                    try
                    {
                        cmd.Parameters.Add(comp);
                        cmd.Parameters.Add(hum);
                        if (idR != -1)
                            cmd.Parameters.Add(role);
                        cmd.Parameters.Add(qua);
                        cmd.ExecuteNonQuery();
                        if (Convert.ToInt32(qua.Value) == 0)
                            MessageBox.Show("Не удалось добавить участника");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static int AddRole(string name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter n = new SqlParameter
                    {
                        ParameterName = "@название",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    cmd = new SqlCommand("SELECT КодРоли FROM Роль WHERE Название = @название", conn);
                    cmd.Parameters.Add(n);
                    int id;
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    if (id != 0)
                    {
                        return id;
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("INSERT INTO Роль VALUES(@название); SET @колИзмен = @@IDENTITY", conn);

                        try
                        {
                            cmd.Parameters.Add(n);
                            cmd.Parameters.Add(qua);
                            cmd.ExecuteNonQuery();
                            return Convert.ToInt32(qua.Value);
                        }
                        catch (Exception ex)
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private static int AddHum(string secName, string name, string patronymic, string dateOfBirth, string sex, bool isCSV)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter f = new SqlParameter
                    {
                        ParameterName = "@фамилия",
                        SqlDbType = SqlDbType.VarChar,
                        Value = secName
                    };

                    SqlParameter n = new SqlParameter
                    {
                        ParameterName = "@имя",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };

                    SqlParameter p = new SqlParameter
                    {
                        ParameterName = "@отчество",
                        SqlDbType = SqlDbType.VarChar,
                        Value = patronymic
                    };

                    SqlParameter d = new SqlParameter
                    {
                        ParameterName = "@датаРождения",
                        SqlDbType = SqlDbType.Date
                    };

                    try
                    {
                        if (isCSV)
                            d.Value = DateTime.ParseExact(dateOfBirth, "dd.MM.yyyy", null);
                        else
                            d.Value = DateTime.ParseExact(dateOfBirth, "dd.MM.yyyy H:mm:ss", null);
                    }
                    catch
                    {
                        d.Value = "";
                    }

                    SqlParameter s = new SqlParameter
                    {
                        ParameterName = "@пол",
                        SqlDbType = SqlDbType.Char
                    };
                    try
                    {
                        s.Value = Convert.ToChar(sex);
                    }
                    catch
                    {
                        s.Value = "";
                    }

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };


                    cmd = new SqlCommand("INSERT INTO Человек VALUES(@фамилия, @имя, ", conn);

                    if (patronymic.ToString() == "")
                        cmd.CommandText += "NULL, ";
                    else
                        cmd.CommandText += "@отчество, ";
                    if (d.Value.ToString() == "")
                        cmd.CommandText += "NULL, ";
                    else
                        cmd.CommandText += "@датаРождения, ";
                    if (s.Value.ToString() == "")
                        cmd.CommandText += "NULL";
                    else
                        cmd.CommandText += "@пол";
                    cmd.CommandText += "); SET @колИзмен = @@IDENTITY";
                    try
                    {
                        cmd.Parameters.Add(f);
                        cmd.Parameters.Add(n);
                        if (patronymic != "")
                            cmd.Parameters.Add(p);
                        if (dateOfBirth != "")
                            cmd.Parameters.Add(d);
                        if (sex != "")
                            cmd.Parameters.Add(s);
                        cmd.Parameters.Add(qua);

                        cmd.ExecuteNonQuery();

                        return Convert.ToInt32(qua.Value);
                    }
                    catch (Exception ex)
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public static void ExportCriteria(char type, int idSubCri, int idHuman)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Соревнование.Название, Фамилия, Имя, Отчество, " +
                        "КомпетенцияWS.КодКомпетенции, КомпетенцияWS.Название, Критерий.Буква, Подкритерий.Номер, Подкритерий.Название, " +
                        "Аспект.Номер AS [НомерАспекта], Подкритерий.НомерСессии, Аспект.МаксимальныйБалл, Аспект.Описание, Пояснение.Оценка, " +
                        "Пояснение.Текст FROM Человек LEFT JOIN Участник ON Человек.КодЧеловека = Участник.КодЧеловека " +
                        "LEFT JOIN Соревнование ON Участник.КодСоревнования = Соревнование.КодСоревнования " +
                        "RIGHT JOIN КомпетенцияWS ON Соревнование.КодКомпетенции = КомпетенцияWS.КодКомпетенции " +
                        "LEFT JOIN Критерий ON Соревнование.КодСоревнования = Критерий.КодСоревнования " +
                        "LEFT JOIN Подкритерий ON Критерий.КодКритерия = Подкритерий.КодКритерия " +
                        "LEFT JOIN Аспект ON Подкритерий.КодПодкритерия= Аспект.КодПодкритерия " +
                        "LEFT JOIN Пояснение ON Аспект.КодАспекта = Пояснение.КодАспекта " +
                        "WHERE Человек.КодЧеловека = " + idHuman + " AND Аспект.Тип = '" + type + "' AND Подкритерий.КодПодкритерия = " + idSubCri +
                        "ORDER BY Подкритерий.Номер, НомерАспекта, Пояснение.Оценка", conn);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (dt.Rows.Count != 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.DefaultExt = "*.docx";
                    sfd.Filter = "Word (*docx)|*.docx";
                    sfd.Title = "Выберите документ для выгрузки данных";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Word.Application app = new Word.Application();
                        Word.Document wordDocument;
                        Word.Table table;
                        Word.Range rng;
                        try
                        {
                            File.WriteAllBytes(sfd.FileName.ToString(), Properties.Resources.Aspects);

                            wordDocument = app.Documents.Open(sfd.FileName.ToString());

                            rng = wordDocument.Paragraphs[1].Range;
                            if (type == 'J')
                                rng.Find.Execute(FindText: "[Type]", MatchCase: true, MatchWholeWord: true, Format: true, Replace: Word.WdReplace.wdReplaceOne, ReplaceWith: "Judgement");
                            else
                                rng.Find.Execute(FindText: "[Type]", MatchCase: true, MatchWholeWord: true, Format: true, Replace: Word.WdReplace.wdReplaceOne, ReplaceWith: "Objective");

                            rng = wordDocument.Paragraphs[3].Range;
                            rng.Find.Execute(FindText: "[Competition]", MatchCase: true, MatchWholeWord: true, Format: true, Replace: Word.WdReplace.wdReplaceOne, ReplaceWith: dt.Rows[0][0].ToString());

                            table = wordDocument.Tables[1];
                            table.Cell(1, 2).Range.Text = dt.Rows[0][4].ToString();
                            table.Cell(1, 4).Range.Text = dt.Rows[0][5].ToString();
                            table.Cell(2, 2).Range.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString() + " " + dt.Rows[0][3].ToString();
                            table.Cell(3, 2).Range.Text = dt.Rows[0][8].ToString();
                            table.Cell(3, 4).Range.Text = dt.Rows[0][6].ToString() + dt.Rows[0][7].ToString();

                            table = wordDocument.Tables[2];
                            int row = 0;
                            int col = 1;
                            int idAsp;
                            double MaxMark = 0;
                            int wr = 2;
                            if (type == 'J')
                            {
                                DataRow dr;
                                while (row < dt.Rows.Count)
                                {
                                    table.Cell(wr, col++).Range.Text = "J" + dt.Rows[row][9].ToString();
                                    table.Cell(wr, col++).Range.Text = dt.Rows[row][10].ToString() != "0" ? dt.Rows[row][10].ToString() : "";
                                    table.Cell(wr, col++).Range.Text = dt.Rows[row][11].ToString();
                                    MaxMark += Convert.ToDouble(dt.Rows[row][11]);
                                    table.Cell(wr, ++col).Range.Text = dt.Rows[row][12].ToString();
                                    row++;
                                    idAsp = Convert.ToInt32(dt.Rows[row][9]);
                                    for (int k = 0; k < 4; k++)
                                    {
                                        if (k!=0)
                                            table.Cell(wr, 4).Range.Text = k.ToString();
                                        dr = dt.Select("НомерАспекта = " + idAsp + " AND Оценка = " + k)[0];
                                        if (dt != null)
                                        {
                                            table.Cell(wr, 5).Range.Text = dr[14].ToString();
                                            row++;
                                        }
                                        wr++;
                                    }
                                    col = 1;
                                }
                            }
                            else
                            {
                                List<DataRow> drs = new List<DataRow>();
                                while (row < dt.Rows.Count)
                                {
                                    table.Cell(wr, col++).Range.Text = "O" + dt.Rows[row][9].ToString();
                                    table.Cell(wr, col++).Range.Text = dt.Rows[row][10].ToString() != "0" ? dt.Rows[row][10].ToString() : "";
                                    table.Cell(wr, col++).Range.Text = dt.Rows[row][11].ToString();
                                    MaxMark += Convert.ToDouble(dt.Rows[row][11]);
                                    table.Cell(wr, ++col).Range.Text = dt.Rows[row][12].ToString();
                                    idAsp = Convert.ToInt32(dt.Rows[row][9]);
                                    row++;
                                    wr++;
                                    drs.Clear();
                                    drs.AddRange(dt.Select("НомерАспекта = " + idAsp + "AND Текст IS NOT NULL"));
                                    foreach (DataRow dr in drs)
                                    {
                                        table.Cell(wr, 5).Range.Text = dr[14].ToString();
                                        wr++;
                                        row++;
                                    }
                                    col = 1;
                                }
                            }
                            rng = wordDocument.Paragraphs[283].Range;
                            if (rng.Find.Execute(FindText: "[MaxM]", MatchCase: true, MatchWholeWord: true, Format: true, Replace: Word.WdReplace.wdReplaceOne, ReplaceWith: MaxMark))

                            wordDocument.Save();
                            app.Quit();
                            MessageBox.Show("Бланк оценивания сохранен");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            app.Quit();
                        }
                    }
                }
                else
                    MessageBox.Show("У выбранного подкритерия нет аспектов типа "+type);
            }
        }

        public static DataTable FillAssessment(int idSubCri, int idHum, char type)
        {
            DataTable dtAll = new DataTable();
            DataTable dtMark = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Тип, Аспект.Номер, Аспект.Описание, МаксимальныйБалл AS [Максимальный балл], Аспект.КодАспекта FROM Аспект " +
                        "LEFT JOIN Подкритерий ON Аспект.КодПодкритерия = Подкритерий.КодПодкритерия " +
                        "LEFT JOIN Критерий ON Подкритерий.КодКритерия = Критерий.КодКритерия " +
                        "LEFT JOIN Соревнование ON Критерий.КодСоревнования = Соревнование.КодСоревнования " +
                        "LEFT JOIN Участник ON Соревнование.КодСоревнования = Участник.КодСоревнования " +
                        "WHERE Аспект.КодПодкритерия = " + idSubCri + "AND Тип = '" + type + "' AND КодЧеловека = " + idHum + " ORDER BY Аспект.Номер", conn);
                    da.Fill(dtAll);
                    dtAll.Columns.Add();
                    da = new SqlDataAdapter("SELECT Оценивание.КодАспекта, Оценка FROM Оценивание " +
                        "JOIN Аспект ON Оценивание.КодАспекта = Аспект.КодАспекта " +
                        "WHERE КодЧеловека = "+idHum + " AND КодПодкритерия = "+ idSubCri + " AND Тип = '" + type+"'", conn);
                    da.Fill(dtMark);
                    
                    for (int i =0;i<dtMark.Rows.Count;i++)
                    {
                        if (dtAll.Select("КодАспекта = " + dtMark.Rows[i][0]).Count() > 0)
                            dtAll.Select("КодАспекта = " + dtMark.Rows[i][0])[0][5] = dtMark.Rows[i][1];
                    }
                    return dtAll;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void SaveAssessment(int idHum, int idComp, int idAsp, double mark, ref int count)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    SqlParameter idH = new SqlParameter
                    {
                        ParameterName = "@кодЧеловека",
                        SqlDbType = SqlDbType.Int,
                        Value = idHum
                    };

                    SqlParameter idC = new SqlParameter
                    {
                        ParameterName = "@кодСоревнования",
                        SqlDbType = SqlDbType.Int,
                        Value = idComp
                    };

                    SqlParameter idA = new SqlParameter
                    {
                        ParameterName = "@кодАспекта",
                        SqlDbType = SqlDbType.Int,
                        Value = idAsp
                    };

                    SqlParameter mar = new SqlParameter
                    {
                        ParameterName = "@оценка",
                        SqlDbType = SqlDbType.Decimal,
                        Value = mark
                    };

                    SqlParameter qua = new SqlParameter
                    {
                        ParameterName = "@колИзмен",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int
                    };

                    cmd = new SqlCommand("SELECT * FROM Оценивание WHERE КодЧеловека = @кодЧеловека AND КодСоревнования = @кодСоревнования AND КодАспекта = @кодАспекта", conn);
                    cmd.Parameters.Add(idH);
                    cmd.Parameters.Add(idC);
                    cmd.Parameters.Add(idA);


                    if (cmd.ExecuteScalar() != null)
                    {
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("UPDATE Оценивание SET Оценка = @оценка WHERE КодЧеловека = @кодЧеловека AND КодСоревнования = @кодСоревнования AND КодАспекта = @кодАспекта; SET @колИзмен = @@ROWCOUNT", conn);
                        cmd.Parameters.Add(idH);
                        cmd.Parameters.Add(idC);
                        cmd.Parameters.Add(idA);
                        cmd.Parameters.Add(mar);
                        cmd.Parameters.Add(qua);

                        cmd.ExecuteNonQuery();
                        if (Convert.ToInt32(qua.Value) == 0)
                            MessageBox.Show("Не уалось изменить оценку");
                        else
                            count++;
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("INSERT INTO Оценивание VALUES(@кодСоревнования, @кодЧеловека, @кодАспекта, @оценка); SET @колИзмен = @@ROWCOUNT", conn);
                        cmd.Parameters.Add(idC);
                        cmd.Parameters.Add(idH);
                        cmd.Parameters.Add(idA);
                        cmd.Parameters.Add(mar);
                        cmd.Parameters.Add(qua);

                        cmd.ExecuteNonQuery();
                        if (Convert.ToInt32(qua.Value) == 0)
                            MessageBox.Show("Не уалось добавить оценку");
                        else
                            count++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Сохранение результатов соревнования в файл
        /// </summary>
        /// <param name="idComp">Код соревнования</param>
        public static void SaveResults(int idComp)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT КомпетенцияWS.КодКомпетенции, КомпетенцияWS.Название, " +
                        "Соревнование.Название, Фамилия, Имя, Отчество, SUM(Оценка) AS [Баллы] " +
                        "FROM КомпетенцияWS RIGHT JOIN Соревнование ON КомпетенцияWS.КодКомпетенции = Соревнование.КодКомпетенции " +
                        "LEFT JOIN Участник ON Соревнование.КодСоревнования = Участник.КодСоревнования " +
                        "LEFT JOIN Человек ON Участник.КодЧеловека = Человек.КодЧеловека " +
                        "LEFT JOIN Оценивание ON Участник.КодСоревнования = Оценивание.КодСоревнования AND Участник.КодЧеловека = Оценивание.КодЧеловека " +
                        "WHERE Участник.КодСоревнования = " + idComp + "  GROUP BY Оценивание.КодЧеловека, Фамилия, Имя, Отчество, " +
                        "КомпетенцияWS.КодКомпетенции, КомпетенцияWS.Название, Соревнование.Название ORDER BY Баллы DESC", conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Не удалось выполнить экспорт");
                return;
            }
            // Создание диалогового окна сохранения файла
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.docx";
            sfd.Filter = "Word (*docx)|*.docx";
            sfd.Title = "Выберите документ для выгрузки данных";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Word.Application app = new Word.Application();
                Word.Document wordDocument;
                Word.Table table;
                Word.Range rng;
                try
                {
                    // Копирование файла из ресурсов по выбранному пользователем пути
                    File.WriteAllBytes(sfd.FileName.ToString(), Properties.Resources.Result);

                    // Открытие файла
                    wordDocument = app.Documents.Open(sfd.FileName.ToString());

                    if (dt.Rows.Count != 0)
                    {
                        // Присвоение переменной типа Word.Range третего абзаца
                        rng = wordDocument.Paragraphs[3].Range;
                        rng.Find.Execute(FindText: "[Competition]", MatchCase: true, MatchWholeWord: true, Format: true, Replace: Word.WdReplace.wdReplaceOne, ReplaceWith: dt.Rows[0][2].ToString());

                        // Присвоение переменной типа Word.Range первой таблицы
                        table = wordDocument.Tables[1];
                        // Запись значения в ячейку таблицы
                        table.Cell(1, 2).Range.Text = dt.Rows[0][0].ToString();
                        table.Cell(1, 4).Range.Text = dt.Rows[0][1].ToString();

                        table = wordDocument.Tables[2];

                        int row = 0;
                        int col;
                        while (row < dt.Rows.Count)
                        {
                            col = 1;
                            table.Cell(row + 2, col++).Range.Text = (row+1).ToString();
                            table.Cell(row + 2, col++).Range.Text = dt.Rows[row][3].ToString() + " " + dt.Rows[row][4].ToString() + " " + dt.Rows[row][5].ToString();
                            table.Cell(row + 2, col++).Range.Text = dt.Rows[row][6].ToString();
                            row++;
                        }
                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(ConnString))
                        {
                            conn.Open();
                            SqlDataAdapter da = new SqlDataAdapter("SELECT КомпетенцияWS.КодКомпетенции, КомпетенцияWS.Название, " +
                                "Соревнование.Название FROM Соревнование LEFT JOIN КомпетенцияWS " +
                                "ON Соревнование.КодКомпетенции = КомпетенцияWS.КодКомпетенции WHERE Соревнование.КодСоревнования = " + idComp, conn);
                            da.Fill(dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            rng = wordDocument.Paragraphs[3].Range;
                            rng.Find.Execute(FindText: "[Competition]", MatchCase: true, MatchWholeWord: true, Format: true, Replace: Word.WdReplace.wdReplaceOne, ReplaceWith: dt.Rows[0][2].ToString());

                            table = wordDocument.Tables[1];
                            table.Cell(1, 2).Range.Text = dt.Rows[0][0].ToString();
                            table.Cell(1, 4).Range.Text = dt.Rows[0][1].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Соревнование не найдено");
                            return;
                        }
                    }
                    // Сохранение файла
                    wordDocument.Save();
                    // Выход из приложения
                    app.Quit();
                    MessageBox.Show("Экспорт результатов соревнования выполнен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Не удалось выполнить экспорт");
                    app.Quit();
                }
            }
        }
    }
}
