using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РеестрКонтроля_КЗ
{
    public class Class1
    {

        static public void loadgridOmron(DataGridView grid, string cmd) //Достает с базы PSIGMA FLAT и преобразует в грид, таблицу
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source= 192.168.37.100\orprovision; Initial Catalog= ; CTS_SOFT; Password = kjifhf123;");
                SqlCommand c = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sqlcon.Open();
                c = sqlcon.CreateCommand();
                c.CommandText = cmd;
                da.SelectCommand = c;
                da.Fill(ds, "Table1");

                grid.DataSource = ds;
                grid.DataMember = "Table1";
                sqlcon.Close();
            }
            catch (Exception)
            {


            }


        }


        static public void loadgrid(DataGridView grid, string cmd) //Достает с базы PSIGMA FLAT и преобразует в грид, таблицу
        {

            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source= traceability\flat; Initial Catalog= ; CTS_SOFT; Password = wnc_ghju;");
                SqlCommand c = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sqlcon.Open();
                c = sqlcon.CreateCommand();
                c.CommandText = cmd;
                da.SelectCommand = c;
                da.Fill(ds, "Table1");

                grid.DataSource = ds;
                grid.DataMember = "Table1";
                sqlcon.Close();
            }


            catch (Exception)
            {


            }

        }


        static public void loadgrid(ComboBox grid, string cmd) //Достает с базы PSIGMA FLAT и преобразует в грид, таблицу
        {

            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source= traceability\flat; Initial Catalog= ; CTS_SOFT; Password = wnc_ghju;");
                SqlCommand c = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sqlcon.Open();
                c = sqlcon.CreateCommand();
                c.CommandText = cmd;
                da.SelectCommand = c;
                da.Fill(ds, "Table1");

                grid.DataSource = ds;
                grid.DisplayMember = "Table1";
                sqlcon.Close();
            }


            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }

        }

        public static object SelectStringOmron(string cmd) //Достает с базы PSIGMA FLAT строковые значения и числовые
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source= 192.168.37.100\orprovision; Initial Catalog= ; CTS_SOFT; Password = kjifhf123;");
            SqlCommand c = new SqlCommand();
            SqlDataReader r;
            string k = "";
            c = sqlcon.CreateCommand();
            c.CommandType = CommandType.Text;
            c.CommandText = cmd;
            try
            {
                sqlcon.Open();
                r = c.ExecuteReader();
                if (r.Read())
                {
                    k = r.GetString(0);
                    r.Close();
                }

                sqlcon.Close();
                return k;
            }


            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                return k;
            }
        }

        public static object SelectString(string cmd) //Достает с базы PSIGMA FLAT строковые значения и числовые
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source= traceability\flat; Initial Catalog= ; CTS_SOFT; Password = wnc_ghju;");
            SqlCommand c = new SqlCommand();
            SqlDataReader r;
            string k = "";
            c = sqlcon.CreateCommand();
            c.CommandType = CommandType.Text;
            c.CommandText = cmd;
            try
            {
                sqlcon.Open();
                r = c.ExecuteReader();
                if (r.Read())
                {
                    k = r.GetString(0);
                    r.Close();
                }

                sqlcon.Dispose();
                return k;
            }


            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                return k;
            }

        }

        public static bool SelectStringBool(string cmd) //Достает с базы PSIGMA FLAT строковые значения и числовые
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source= traceability\flat; Initial Catalog= ; CTS_SOFT; Password = wnc_ghju;");
            SqlCommand c = new SqlCommand();
            SqlDataReader r;
            bool k = false;
            c = sqlcon.CreateCommand();
            c.CommandType = CommandType.Text;
            c.CommandText = cmd;
            try
            {
                sqlcon.Open();
                r = c.ExecuteReader();
                if (r.Read())
                {
                    k = r.GetBoolean(0);
                    r.Close();
                }

                sqlcon.Dispose();
                return k;
            }


            catch (Exception e)
            {

                //MessageBox.Show(e.ToString());
                return k;
            }

        }

        public static object SelectStringDate(string cmd) //Достает с базы PSIGMA FLAT строковые значения и числовые
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source= traceability\flat; Initial Catalog= ; CTS_SOFT; Password = wnc_ghju;");
            SqlCommand c = new SqlCommand();
            SqlDataReader r;
            //Datetime k = "";
            DateTime k = new DateTime();
            c = sqlcon.CreateCommand();
            c.CommandType = CommandType.Text;
            c.CommandText = cmd;
            try
            {
                sqlcon.Open();
                r = c.ExecuteReader();
                if (r.Read())
                {
                    //k = r.GetString(0);
                    k = r.GetDateTime(0);
                    r.Close();
                }
                //MessageBox.Show(k);
                sqlcon.Close();
                return k;
            }


            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                return k;
            }

        }

        public static object SelectStringIntOmron(string cmd) //Достает с базы PSIGMA FLAT строковые значения и числовые
        {


            SqlConnection sqlcon = new SqlConnection(@"Data Source= 192.168.37.100\orprovision; Initial Catalog= ; CTS_SOFT; Password = kjifhf123;");
            SqlCommand c = new SqlCommand();
            SqlDataReader r;
            int k = 0;
            c = sqlcon.CreateCommand();
            c.CommandType = CommandType.Text;
            c.CommandText = cmd;
            try
            {
                sqlcon.Open();
                r = c.ExecuteReader();
                if (r.Read())
                {
                    k = r.GetInt32(0);
                    r.Close();

                }
                sqlcon.Close();
                return k;
                //MessageBox.Show(k);
                //sqlcon.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return k;
            }
        }


        public static void MsgBox(string msg)
        {
            MessageBox.Show(msg);
        }

        public static int LogginID(string name)
        {

            string SQL;
            SQL = @"use FAS Select UserID FROM [FAS].[dbo].[M_Users] where UserName = '" + name + "'";
            return Convert.ToInt32(SelectStringInt(SQL));


        }

        public static void Loggin(TextBox RFID, TextBox Result, Label error, Boolean Проверка = false)
        {

            string SQL;
            object Check_Rfid;
            SQL = @"use FAS Select UserName FROM [FAS].[dbo].[M_Users] where RFID = '" + RFID.Text + "'";
            Check_Rfid = SelectString(SQL);
            if (Check_Rfid.ToString() == "")
            {
                error.Text = "Пользователь не найден";
                error.Visible = true;
                RFID.Clear();
                RFID.Select();
                Проверка = false;

            }
            else
            {

                Result.Text = Check_Rfid.ToString();
                error.Text = "";
                RFID.Clear();
                RFID.Enabled = false;
                Проверка = true;
            }

        }

        public static void Loggin(TextBox RFID, Label Result, Label error, Boolean Проверка = false)// Лейбл вывод
        {

            string SQL;
            object Check_Rfid;
            SQL = @"use FAS Select UserName FROM [FAS].[dbo].[M_Users] where RFID = '" + RFID.Text + "'";
            Check_Rfid = SelectString(SQL);
            if (Check_Rfid.ToString() == "")
            {
                error.Text = "Пользователь не найден";
                error.Visible = true;
                RFID.Clear();
                RFID.Select();
                Проверка = false;

            }
            else
            {

                Result.Text = Check_Rfid.ToString();
                error.Text = "";
                RFID.Clear();
                RFID.Enabled = false;
                Проверка = true;
            }

        }


        public static object SelectStringInt16(string cmd) //Достает с базы PSIGMA FLAT строковые значения и числовые
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source= traceability\flat; Initial Catalog= ; CTS_SOFT; Password = wnc_ghju;");
            SqlCommand c = new SqlCommand();
            SqlDataReader r;
            int k = 0;
            c = sqlcon.CreateCommand();
            c.CommandType = CommandType.Text;
            c.CommandText = cmd;
            try
            {
                sqlcon.Open();
                r = c.ExecuteReader();
                if (r.Read())
                {
                    k = r.GetInt16(0);
                    r.Close();

                }
                sqlcon.Close();
                return k;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return k;
            }


        }

        public static object SelectStringInt(string cmd) //Достает с базы PSIGMA FLAT строковые значения и числовые
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source= traceability\flat; Initial Catalog= ; CTS_SOFT; Password = wnc_ghju;");
            SqlCommand c = new SqlCommand();
            SqlDataReader r;
            int k = 0;
            c = sqlcon.CreateCommand();
            c.CommandType = CommandType.Text;
            c.CommandText = cmd;
            try
            {
                sqlcon.Open();
                r = c.ExecuteReader();
                if (r.Read())
                {
                    k = r.GetInt32(0);
                    r.Close();

                }
                sqlcon.Close();
                return k;
                //MessageBox.Show(k);
                //sqlcon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return k;
            }


        }


     



        public static void ОтправкаСообщения(string model, string Status = "")
        {
            string date;
            date = DateTime.Now.ToString();
            var content = $@"
                    <style type=""text/css"">
                        body {{ font-family: Arial; font-size: 14pt; }}
                    </style>
                    <body>
                             Добрый день! Сформирован новый отчёт     <a href='\\192.168.180.9\prodsoft\РеестрКомерческихЗаказов\РежимыРеестраКЗ.application'>Реестр комерческих заказов</a>"
                + "   <br> </br>   </body>      <body>  " + Status + "  </body> <br> </br>  <body> Имя заказа -  " + model + " </body>";

            // Update content with picture guid
            // Create Alternate View
            var view = AlternateView.CreateAlternateViewFromString(content, Encoding.UTF8, MediaTypeNames.Text.Html);
            // Add the resources


            try
            {
                using (var client = new SmtpClient("mail.technopolis.gs", 25)) // Set properties as needed or use config file
                using (MailMessage message = new MailMessage()
                {
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8,
                    Subject = "РеестрКомерческихЗаказов - " + model + "",
                    SubjectEncoding = Encoding.UTF8,

                })
                {
                    message.AlternateViews.Add(view);
                    message.From = new MailAddress("controlerotk@dtvs.ru", "Контроллер-ОТК  " + date + "");
                    message.To.Add(new MailAddress("a.volodin@dtvs.ru"));
                    //message.CC.Add("Редкозубов Алексей Сергеевич <redkozubov@dtvs.ru>");
                    message.CC.Add("Гусаров Валерий Вячеславович <gusarov@dtvs.ru>");
                    //message.CC.Add("Слабицкая Татьяна Михайловна <slabitskaya@dtvs.ru>");
                    message.CC.Add("Костина Ксения Викторовна <kostina@dtvs.ru>");
                    message.CC.Add("Лишик Станислав Александрович <lishik@dtvs.ru>");
                    message.CC.Add("Овчинников Дмитрий Игоревич <ovchinnikov@dtvs.ru>");
                    message.CC.Add("Ященко Петр Владимирович <yashenko@dtvs.ru>");
                    message.CC.Add("Контролер ОТК <controlerotk@dtvs.ru>");
                    //message.CC.Add("Абдуллаев Алишер Рашитович <a.abdullaev@dtvs.ru>");
                    message.CC.Add("Мастер SMT <mastersmt@dtvs.ru>");
                    message.CC.Add("Парфенов Евгений Александрович <parfenov@dtvs.ru>");
                    message.CC.Add("Лихачёва Валерия Сергеевна <v.lihacheva@dtvs.ru>");
                    message.CC.Add("Баранова Мария Владимировна <m.baranova@dtvs.ru>");

                    client.Send(message);
                    MessageBox.Show("Сообщение отправлено!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при отправление сообщения", "Ошибка отправки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(e.ToString());

            }


        }

    }
}
