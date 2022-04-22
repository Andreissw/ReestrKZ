using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ModuleConnect;
using РежимыРеестраКЗ;

namespace РеестрКонтроля_КЗ
{
    public partial class ГлавнаяФорма : Form
    {
        public ГлавнаяФорма()
        {
            InitializeComponent();
        }

        public static int k = 0;
        string loggin;
        public static bool AQL;
        public static bool checkform = false;

        void Ограничение()
        {

        }

        void Режим_для_просмотра()
        {
          
            NamePaste.Enabled = false;
            CoutnRel.ReadOnly = true;
            CountCheck.ReadOnly = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
                      
            ControllerSG.ReadOnly = true;
            MasterSG.ReadOnly = true;
            VedinjerSG.ReadOnly = true;
            InjerKPPSG.ReadOnly = true;
            textBox2.ReadOnly = true;

            Таблица1.ReadOnly = true;
            Таблица2.ReadOnly = true;



        }

        string имяПасты(int mode)
        {
            string sql;
            sql = @" use QA SELECT PasteName  FROM [QA].[dbo].[Registry_SMT_Table1] as tb  left join Registry_PasteName as ps on tb.idNamePaste = ps.id
                     inner join Registry_Name as nm on tb.idNameProduct = nm.id   inner join Registry_ProjectDate as pr on tb.idNameProduct = pr.idNameProduct   where iduser = '" + Form1.idus + "' and nm.id = '" + Form1.key + "' and tb.idmode = '" + mode + "' and date = '" + Form1.Дата + "'";

            return Class1.SelectString(sql).ToString();

        }

        void Проверки()
        {
            var sql = $@"USE QA SELECT  [IsTermo] ,[IsElProtocol] ,[IsEtalon],[IsAssemblyDraw]  FROM[QA].[dbo].[Registry_Name]  where id = {Form1.key}";
            Class1.loadgrid(GridChecks,sql);
            List<bool> lists = new List<bool>();

            for (int i = 0; i < GridChecks.Columns.Count; i++) {

                var result = bool.TryParse(GridChecks[i, 0].Value.ToString(),out bool _re);
                if (!result) continue;
                lists.Add(_re);
            }

            if (lists.Count != 4) return;


            if (lists[0]) radioButton3.Checked = true;
            else radioButton4.Checked = true;

            if (lists[1]) radioButton5.Checked = true;
            else radioButton6.Checked = true;

            if (lists[2]) radioButton7.Checked = true;
            else radioButton8.Checked = true;

            if (lists[3]) radioButton9.Checked = true;
            else radioButton10.Checked = true;
        }

        void Паста(int mode)
        {
            string sql;
            sql = @"USE QA SELECT smt.idTypePaste  FROM [QA].[dbo].[Registry_SMT_Table1] as smt 
                 Inner join Registry_ProjectDate as dt on smt.idDateCreate = dt.id  inner join Registry_Name as nm on smt.idNameProduct = nm.id
                where iduser = '" + Form1.idus + "'  and nm.id = '" + Form1.key + "'  and idRow = 1 and SMT.idmode = '" + mode + "' and date = '" + Form1.Дата + "'";

            if (Class1.SelectStringInt16(sql).ToString() == "1")
            {
                radioButton1.Checked = true;
            }
            else if ((Class1.SelectStringInt16(sql).ToString() == "2"))
            {
                radioButton2.Checked = true;
            }
        }

        string Выгрузкаколичества(string column, int mode)
        {
            object k;
            string sql;
            sql = @"USE QA SELECT  [" + column + "]     FROM [QA].[dbo].[Registry_TableCounter] as tb  inner join Registry_ProjectDate as pr on tb.idName = pr.idNameProduct " +
                    "inner join Registry_Name as NA on tb.idName = NA.id    where NA.id = '" + Form1.key + "' and idUser = '" + Form1.idus + "' and tb.idmode = '" + mode + "' and date = '" + Form1.Дата + "'";
            k = Class1.SelectStringInt(sql);
            if (k.ToString() != "0")
                 return k.ToString();
            return "";
        }

        string Выгрузкаколичестваstring(string column, int mode)
        {

            string sql;
            sql = @"USE QA SELECT  [" + column + "]     FROM [QA].[dbo].[Registry_TableCounter] as tb  inner join Registry_ProjectDate as pr on tb.idName = pr.idNameProduct   " +
                "inner join Registry_Name as NA on tb.idName = NA.id " +
                " where NA.id = '" + Form1.key + "' and idUser = '" + Form1.idus + "' and tb.idmode = '" + mode + "'";
            return Class1.SelectString(sql).ToString();

        }


        void Выгрузка_данных_таблица2(int mode)
        {
            string sql;
            sql = @"USE QA SELECT       [CountForCheck]      ,[CountCheck] ,[CountDefects]     ,[DefectCode]
                    ,[Position]      ,[Description]      ,[Rem]  ,[AqvDefectfixed]     FROM [QA].[dbo].[Registry_SMT_Table2] as TB  Inner join Registry_ProjectDate as dt on tb.idDateCreate = dt.id  inner join Registry_Name as nm on tb.idNameProduct = nm.id
                where  nm.id = '" + Form1.key + "'  and idUser = '" + Form1.idus + "' and TB.idmode = '" + mode + "' order by idRow";
            Class1.loadgrid(Загрузка_Грид2, sql);

    
        }

        void Выгрузка_данных_таблица1( int mode)

        {
       
            string sql;
            sql = @"Use QA  SELECT Line, Lot,Spec, countProd, CountTest, CountPassTest, CountFailTest, fpy,Defects, Decription  FROM [QA].[dbo].[Registry_SMT_Table1] as TB
                Inner join Registry_ProjectDate as dt on tb.idDateCreate = dt.id  inner join Registry_Name as nm on tb.idNameProduct = nm.id
                where  nm.id = '" + Form1.key + "' and idUser = '" + Form1.idus + "' and TB.idmode = '" + mode + "' order by idRow";
            Class1.loadgrid(ЗагрузкаGrid, sql);

        }



        object Grid2(int row, int col)
        {
            return Загрузка_Грид2.Rows[row].Cells[col].Value;
        }

        void ФункцияЗаполнениеТаблицбул(CheckBox CB, int row, int col, DataGridView грид)
        {
            try
            {
                CB.Checked = Convert.ToBoolean(грид.Rows[row].Cells[col].Value);
            }
            catch (Exception) { }

        }

       

       

        void ЗаполнениеТаблица1(DataGridView ЗагрузкаГрид, DataGridView Таблица_Грид )
        {
            
            for (int i = 0; i < ЗагрузкаГрид.RowCount - 1; i++)
            {
                for (int b = 0; b < ЗагрузкаГрид.ColumnCount; b++)
                {
                    if (ЗагрузкаГрид.Rows[i].Cells[b].Value.ToString() != "0")
                    Таблица_Грид.Rows[i].Cells[b].Value = ЗагрузкаГрид.Rows[i].Cells[b].Value;
                }
            }
           

        }

        void Заполенени_2Таблицы()
        {

           
        }

        void ФункцияЗаполнениеТаблиц(TextBox tb, int row, int cells, DataGridView DG)
        {
            try
            {
                tb.Text = DG.Rows[row].Cells[cells].Value.ToString();


            }
            catch (Exception e)
            {

                //Clipboard.SetText(e.ToString());
            }
        }

        string Функция_добавление_Даты(string Dp, int row, int cells, DataGridView DG)
        {


            try
            {
                Dp = DG.Rows[row].Cells[cells].Value.ToString();

            }
            catch (Exception e)
            {

                //Clipboard.SetText(e.ToString());
            }
            return Dp;



        }

        void Загрузка_Подписи(int mode)
        {
            string sql;
            sql = @"USE QA SELECT NameSignature, smt.date, pole1  FROM [QA].[dbo].[Registry_signature] as smt 
            inner join Registry_Name as nm on smt.idNameProduct = nm.id 
             inner join Registry_ProjectDate as pr on smt.idNameProduct = pr.idNameProduct
            where nm.id = '" + Form1.key + "' and idUser = '" + Form1.idus + "' and smt.idmode = '" + mode + "'and pr.date = '" + Form1.Дата + "'";
            Class1.loadgrid(Загрузка_Грид2, sql);
        }




        void вывод_подписей()
        {
            ФункцияЗаполнениеТаблиц(ControllerSG, 0, 0, Загрузка_Грид2);
            ФункцияЗаполнениеТаблиц(MasterSG, 1, 0, Загрузка_Грид2);
            ФункцияЗаполнениеТаблиц(VedinjerSG, 2, 0, Загрузка_Грид2);
            ФункцияЗаполнениеТаблиц(InjerKPPSG, 3, 0, Загрузка_Грид2);

            ФункцияЗаполнениеТаблиц(textBox6, 2, 2, Загрузка_Грид2);
            ФункцияЗаполнениеТаблиц(textBox7, 3, 2, Загрузка_Грид2);

            dateTimePicker1.Text = Функция_добавление_Даты(dateTimePicker1.Text, 0, 1, Загрузка_Грид2);
            dateTimePicker2.Text = Функция_добавление_Даты(dateTimePicker2.Text, 1, 1, Загрузка_Грид2);
            dateTimePicker3.Text = Функция_добавление_Даты(dateTimePicker3.Text, 2, 1, Загрузка_Грид2);
            dateTimePicker4.Text = Функция_добавление_Даты(dateTimePicker4.Text, 3, 1, Загрузка_Грид2);
        }

        void Выводпасты () //В комбобокс добавляет список паст
            {
            string sql;
            sql = @"USE QA SELECT  distinct(PasteName)    FROM [QA].[dbo].[Registry_PasteName]";
            Class1.loadgrid(ЗагрузкаGrid, sql);

            for (int i = 0; i < ЗагрузкаGrid.Rows.Count - 1; i++)
            {
                NamePaste.Items.Add(ЗагрузкаGrid.Rows[i].Cells[0].Value);
            }

            }

        private void ГлавнаяФорма_Load(object sender, EventArgs e)
        {
            LB_Depo.Visible = false;
            Таблица1.Rows.Add(5); //Добавляет в таблицу 1, строки 5 штук
            

            if (Form1.modeAQV == true)
            {
                AQVTable();

            }
            else
            {
                var listnamecolumn = new List<string>() { "Кол-во предъявленных на проверку", "Кол-во проверенных", "Кол-во дефектов", "Код дефекта", "Позиционный номер", "Примечания. Особые отметки", "Подлежит ремонту да/нет","" };
                for (int i = 0; i < 8; i++)
                {
                    if (i != 7)
                    { Таблица2.Columns.Add(i.ToString(), listnamecolumn[i]); continue; }

                    Таблица2.Columns.Add(new DataGridViewCheckBoxColumn());
                    Таблица2.Columns[i].Visible = false;
                }

                //label2.Text = "(не менее 20 % от количества выпущенной продукции)";

            }

            Таблица2.Rows.Add(20); //Добавляет в таблицу 2, строки 20 штук

            for (int k = 0; k < 20; k++)
                Таблица2[7, k].Value = false;    

            Выводпасты(); //В комбобокс добавляет список паст
            
            NamePaste.Select();//Фокус на пасту
            //Ограничение();           
            
            ЗагрузкаЭкрана(ГлавнаяГруппа, ГР, true, 1368, 1042, 12, 3, true); //Настройка формы, ее размеры и координаты           

            if (Form1.Новый_отчёт == true) //Запускается когда проект новый, данных никаких нет
            {
                ModelLabel.Text = Form1.Модель;
                TB1Row1Name.Text = Form1.Модель;
                Date.Text = DateTime.Now.ToString();
                LoginLabel.Text = Form1.Loggin;
                LoginLabel.Visible = true;
                ОчисткаПеременных();
                GetLabelText();
                return;
            }
            else  // Если проект не новый, загружается выбранный проект
            {
                if (Form1.Отчет == true) //Запускается режим просмотра, редактирование запрещено 
                {
                    LoginLabel.Text = Form1.NAMEUSER;
                    LoginLabel.Visible = true;
                    ЗагрузкаПроекта(Form1.mode); //Главная выгрузка данных в таблицы
                    Сохранить.Visible = false;
                    Режим_для_просмотра();
                    Date.Text = Form1.Дата;
                    GetLabelText();
                }
                else if( Form1.Отчет == false ) //Запуск редактирование прошлого проекта
                {
                    LoginLabel.Text = Form1.Loggin;
                    LoginLabel.Visible = true;
                    ЗагрузкаПроекта(Form1.mode); //Главная выгрузка данных в таблицы
                    Date.Text = Form1.Дата;
                    ЗаполенниеПеременныхДляФотоШаблон(Form1.mode);
                    GetLabelText();

                }
                
            }
        }

        void GetLabelText()
        {
            if (Form1.mode == 1)
            { //Переменная Form.mode это выбранный цех, в данном случае SMT

                this.Text = "Реестр Комерческих заказов SMT";
                ЦехLabel.Text = "Отчёт по качеству выпускаемой продукции в ЦПМ";
                label9.Text = "Выборочный визуальный контроль ЦПМ";
                //label7.Text = "Паста";
                label20.Text = "Дефекты после верификации";
                radioButton1.Text = "Свинцовая";
                radioButton2.Text = "Без свинцовая";
            }
            else if (Form1.mode == 2)//Переменная Form.mode это выбранный цех, в данном случае  Цех Сборки
            {
                //редактирование лейблов
                this.Text = "Реестр Комерческих заказов ЦЕХ Сборки";
                ЦехLabel.Text = "Отчёт по качеству выпускаемой продукции в ЦЕХ Сборки";
                label9.Text = "Выборочный визуальный контроль ЦЕХ Сборки";
                //label7.Text = "Припой";
                label20.Text = "Коды отказов при тестировании";
                radioButton1.Text = "Проводилась пайка";
                radioButton2.Text = "Не проводилась пайка";

                if (ModelLabel.ToString().ToUpper().Contains("DP"))
                    LB_Depo.Visible = true;


            }
        }

        private void AQVTable()
        {
            Таблица2.Columns.Clear();
            Таблица2.Rows.Clear();
            var listnamecolumnAQ = new List<string>() { "Кол-во предъявленных на проверку", "Кол-во проверенных", "Кол-во изделий с данным дефектов", "Код дефекта", "Позиционный номер", "Примечания. Особые отметки", "Подлежит ремонту да/нет", "Дефект исправлен" };
            for (int i = 0; i < 8; i++)
            {
                if (i != 7)
                { Таблица2.Columns.Add(i.ToString(), listnamecolumnAQ[i]); continue; }

                Таблица2.Columns.Add(new DataGridViewCheckBoxColumn());
                Таблица2.Columns[i].HeaderText = listnamecolumnAQ[i];


            }
            //label2.Text = "Уровень контроля продукции равен значению AQL 1% (приемлемый уровень качества)";
        }

        void ОчисткаПеременных()
        {
            Photos.pic = "";
            Photos.pic2 =   "";
            Photos.pic3 =   "";
            Photos.pic4 =   "";
            Photos.pic5 =   "";
            Photos.pic6 =   "";
            Photos.pic7 =   "";
            Photos.pic8 =   "";
            Photos.pic9 =   "";
            Photos.pic10  =   "";
             Photos.pic11=   "";
             Photos.pic12 = "";
             Photos.pic13 = "";
             Photos.pic14 = "";
             Photos.pic15 = "";
             Photos.pic16 = "";
             Photos.pic17 = "";
             Photos.pic18 = "";
             Photos.pic19 = "";
             Photos.pic20 = "";
        }

        void ЗаполенниеПеременныхДляФотоШаблон(int mode) //Загрузка по шаблону, записывает в переменные путь картинок который были в сама проекте
        {

            Photos.pic = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 1);
            Photos.pic2 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 2);
            Photos.pic3 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 3);
            Photos.pic4 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 4);
            Photos.pic5 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 5);
            Photos.pic6 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 6);
            Photos.pic7 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 7);
            Photos.pic8 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 8);
            Photos.pic9 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 9);
            Photos.pic10 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 10);
            Photos.pic11 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 11);
            Photos.pic12 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 12);
            Photos.pic13 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 13);
            Photos.pic14 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 14);
            Photos.pic15 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 15);
            Photos.pic16 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 16);
            Photos.pic17 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 17);
            Photos.pic18 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 18);
            Photos.pic19 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 19);
            Photos.pic20 = ЗагрузкаКартинок(Form1.Модель, Form1.idus, mode, 20);
        }

        string ЗагрузкаКартинок(string namePR, string idus, int mode, int numpic) //Запрос картинок
        {
            return Class1.SelectString(@" USE QA SELECT   [pic1]      FROM [QA].[dbo].[Registry_Photos]  smt   inner join Registry_Name as nm on smt.idNameProject = nm.id  
                inner join Registry_ProjectDate as PR on smt.idNameProject = PR.idNameProduct     where  idUser = '" + idus + "' and smt.idMode = '" + mode + "'" +
                " and numPic = '" + numpic + "' and nm.id = '" + Form1.key + "'").ToString();

        }



        private void ЗагрузкаПроекта(int mode)  //Главная выгрузка данных в таблицы
        {
            ModelLabel.Text = Form1.Модель;
            TB1Row1Name.Text = Form1.Модель;
            string sql = "USE QA SELECT TOP 1 [Aqv]  FROM [QA].[dbo].[Registry_Name] where NameProduct = '"+ ModelLabel.Text +"'";
            if (Class1.SelectStringBool(sql))
            { AQVTable(); Таблица2.Rows.Add(20); } //Добавляет в таблицу 2, строки 20 штук




                for (int k = 0; k < 20; k++)
                Таблица2[7, k].Value = false;

            Выгрузка_данных_таблица1(mode); //Выгружает данные таблицы 1
            ЗаполнениеТаблица1(ЗагрузкаGrid,Таблица1); //Цикл который раскидывает данные с таблицы 1 в таблицу проекта
            Паста(mode); //Выгрузка пасты с базы
            Проверки();
            NamePaste.Text = имяПасты(mode); //Загрузка пасты в проект
            CoutnRel.Text = Выгрузкаколичества("CountForRelease",mode);
            CountCheck.Text = Выгрузкаколичества("CountCheckRel",mode);
            textBox2.Text = Выгрузкаколичестваstring("DescpPR", mode);
            Выгрузка_данных_таблица2(mode);
            ЗаполнениеТаблица1(Загрузка_Грид2, Таблица2);
            Загрузка_Подписи(mode);
            вывод_подписей();

            //TB1Row1Name.Enabled = false;
        }

        public static string LogName;


        public static bool buttonPhoto = false;
        private void button2_Click_1(object sender, EventArgs e)
        {

             if (checkform == true)
             MessageBox.Show("Форма для фотографий уже открыта", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
            else
            {
                var photo = new Photos();
                photo.Show();
                buttonPhoto = true;
            }
            


        }

        void ЗагрузкаЭкрана(GroupBox GR, GroupBox GR2, bool видимость = false, int width = 1433, int height = 1000, int locx = 12, int locy = 46, bool автоскрол = true)
        {
            var p = new Point(locx, locy);
            var sz = new Size(0, 0);
            var pt = new Size(width, height);
            GR.Visible = видимость;
            GR.Location = Point.Add(p, sz);

            GR2.Visible = false;

            this.Size = Size.Add(sz, pt);
            this.AutoScroll = автоскрол;


        }

        void bl()
        {
            Photos.bl1 = false;
            Photos.bl2 = false;
            Photos.bl3 = false;
            Photos.bl4 = false;
            Photos.bl5 = false;
            Photos.bl6 = false;
            Photos.bl7 = false;
            Photos.bl8 = false;
            Photos.bl9 = false;
            Photos.bl10 = false;
            Photos.bl11 = false;
            Photos.bl12 = false;
            Photos.bl13 = false;
            Photos.bl14 = false;
            Photos.bl15 = false;
            Photos.bl16 = false;
            Photos.bl17 = false;
            Photos.bl18 = false;
            Photos.bl19 = false;
            Photos.bl20 = false;

            //Photos.pic = "";
            //Photos.pic2 = "";
            //Photos.pic3 = "";
            //Photos.pic4 = "";
            //Photos.pic5 = "";
            //Photos.pic6 = "";
            //Photos.pic7 = "";
            //Photos.pic8 = "";
            //Photos.pic9 = "";
            //Photos.pic10 = "";
            //Photos.pic11 = "";
            //Photos.pic12 = "";
            //Photos.pic13 = "";
            //Photos.pic14 = "";
            //Photos.pic15 = "";
            //Photos.pic16 = "";
            //Photos.pic17 = "";
            //Photos.pic18 = "";
            //Photos.pic19 = "";
            //Photos.pic20 = "";

            Photos.ppic = "";
            Photos.ppic2 = "";
            Photos.ppic3 = "";
            Photos.ppic4 = "";
            Photos.ppic5 = "";
            Photos.ppic6 = "";
            Photos.ppic7 = "";
            Photos.ppic8 = "";
            Photos.ppic9 = "";
            Photos.ppic10 = "";
            Photos.ppic11 = "";
            Photos.ppic12 = "";
            Photos.ppic13 = "";
            Photos.ppic14 = "";
            Photos.ppic15 = "";
            Photos.ppic16 = "";
            Photos.ppic17 = "";
            Photos.ppic18 = "";
            Photos.ppic19 = "";
            Photos.ppic20 = "";

            buttonPhoto = false;

            for (int i = 0; i < Photos.Массив.Length; i++)
            {
                Photos.Массив[i] = "";
            }

        }

        private void Закрыть_Click(object sender, EventArgs e)
        {
            Form1.Отчет = false;
            Form1.Новый_отчёт = false;
            Form1.ОтчетШаблон = false;
            Возврат();
            bl();
            GC.Collect();

        }

        private void ГлавнаяФорма_FormClosed(object sender, FormClosedEventArgs e)
        {


        }
        bool tr = false;
        private void Возврат()
        {
            tr = true;
            this.Hide();
            var РежимОтчета = new Form1();
            РежимОтчета.ShowDialog();
            k = 0;
        }



        private void ГлавнаяФорма_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (tr == false)
            {
                Application.Exit();
            }

        }

          
        public static int Paste;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Paste = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                Paste = 2;
            }
        }

       
        void Сохранение_Проекта()
        {

           
            
            if (radioButton1.Checked == false & radioButton2.Checked == false)
            {
                MessageBox.Show("Запрещено сохранить документ, выберите тип пасты", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return;              
            }

            if (radioButton3.Checked == false & radioButton4.Checked == false)
            {
                MessageBox.Show("Запрещено сохранить документ без информации об актуальности термопрофиля пайки", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (radioButton5.Checked == false & radioButton6.Checked == false)
            {
                MessageBox.Show("Запрещено сохранить документ без информации об заполнении Эл. протокола", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (radioButton7.Checked == false & radioButton8.Checked == false)
            {
                MessageBox.Show("Запрещено сохранить документ без информации об эталонном образце", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (radioButton9.Checked == false & radioButton10.Checked == false)
            {
                MessageBox.Show("Запрещено сохранить документ без информации об сборочном чертеже", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }



            else if (NamePaste.Text == "")
            {
                MessageBox.Show("Запрещено сохранить документ, без наименование пасты", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NamePaste.Select();
            }
            else if (checkform == true) { MessageBox.Show("Закройте форму для фотографий", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            else
            {

                ПервыйМассив(Таблица1, МногомерныйМассив1); //Сохраняет в массив данные с первой таблцы первой строки
                Второй_массив();
                ТретийМассив(); //Сохраняет в массив данные с второй таблцы полностью
                ВторойМассив(Таблица2, МногомерныйМассив2);
                ЧетвертыйМассив();
                ЧетвертыйБул_массив(Таблица2, МногомерныйМассив2Бул);



                //MessageBox.Show(Таблица2.Rows[0].Cells[6].Value.ToString());
                var Сохранение = new Сохранение(GetBools());
                Сохранение.ShowDialog();

            }
        }


        List<bool> GetBools()
        {
            List<bool> listbools = new List<bool>() { };

            if (radioButton3.Checked) listbools.Add(true);
            else  listbools.Add(false);
            if (radioButton5.Checked) listbools.Add(true);
            else listbools.Add(false);
            if (radioButton7.Checked) listbools.Add(true);
            else listbools.Add(false);
            if (radioButton9.Checked) listbools.Add(true);
            else  listbools.Add(false);

            return listbools;
        }

        private void ВторойМассив(DataGridView Таблица, string[,] массив)
        {
           
            for (int i = 0; i < Таблица.RowCount; i++)
            {
                for (int k = 0; k < Таблица.ColumnCount; k++)
                {
                    if (k == 7)
                    {
                        if (Таблица.Rows[i].Cells[k].Value.ToString() == "False") { массив[i, k] = "0";continue; };
                        массив[i, k] = "1"; continue;
                    }

                    if (Таблица.Rows[i].Cells[k].Value != null)
                        массив[i, k] = Таблица.Rows[i].Cells[k].Value.ToString();
                    else                        
                        массив[i, k] = "";
                 }
            }

        }

        private void ПервыйМассив(DataGridView Таблица, string[,] массив)
        {

            for (int i = 0; i < Таблица.RowCount; i++)
            {
                for (int k = 0; k < Таблица.ColumnCount; k++)
                {
                    if (Таблица.Rows[i].Cells[k].Value != null)
                        массив[i, k] = Таблица.Rows[i].Cells[k].Value.ToString();
                    else                       
                    массив[i, k] = "";
                }
            }

        }

        void ЧетвертыйБул_массив(DataGridView Таблица, string[,] массив)
        {
            for (int i = 0; i < Таблица.RowCount; i++)
            {
                if (Таблица.Rows[i].Cells[6].Value != null)
                    массив[i, 0] = Таблица.Rows[i].Cells[6].Value.ToString();
                else
                    массив[i, 0] = "";




             }
        }


        void Второй_массив()
        {
            Массив1[0] = TB1Row1Name.Text;
            Массив1[1] = NamePaste.Text;
            Массив1[2] = textBox6.Text;
            Массив1[3] = textBox7.Text;

        }

     
        private void ТретийМассив()
        {
            Массив12[0] = CoutnRel.Text;
            Массив12[1] = CountCheck.Text;
            Массив12[2] = textBox2.Text;
        }

     

        

        void ЧетвертыйМассив()
        {
            Массив4[0] = ControllerSG.Text;
            Массив4[1] = MasterSG.Text;
            Массив4[2] = VedinjerSG.Text;
            Массив4[3] = InjerKPPSG.Text;
            Массив4[4] = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            Массив4[5] = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            Массив4[6] = dateTimePicker3.Value.ToString("yyyy-MM-dd HH:mm:ss");
            Массив4[7] = dateTimePicker4.Value.ToString("yyyy-MM-dd HH:mm:ss");

        }

        public static string[,] МногомерныйМассив1 = new string[5,10];
        public static string[,] МногомерныйМассив2 = new string[20, 8];
        public static string[,] МногомерныйМассив2Бул = new string[20, 1];
        public static string[] Массив1 = new string[4];
        public static string[] Массив12 = new string[3];
        public static string[] Массив2 = new string[50];
        public static bool[] Массив3 = new bool[50];
        public static string[] Массив4 = new string[50];
       
        private void Сохранить_Click(object sender, EventArgs e)
        {
          
            Сохранение_Проекта();

        }
        #region Ввод только чисел
        private static void ТолькоЧисла(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

     

        #endregion

        private void ГлавнаяФорма_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (Char)Keys.S&&e.Control)
            {
                Сохранение_Проекта();
            }

            if (e.KeyValue == (Char)Keys.R && e.Control)
            {
                Скриншот();
            }
        }

        void Скриншот()
        {
            if (File.Exists(@"C:\Скриншот\Скриншот")) { }
            else { Directory.CreateDirectory(@"C:\Скриншот\"); }

            int k, a, b, c;
            k = this.Width;
            a = this.Height;
            b = this.Location.X;
            c = this.Location.Y;
            Screens(k -20, a - 14, "Скриншот", b + 7, c + 7);
            print();
        }

  

        public  void Screens(int width, int height, string screen, int c, int b)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
           

            Bitmap BM = new Bitmap(width, height);

            Size size = new Size(width, height);
            Point point = new Point(c, b);
            Point point2 = new Point(0, 0);
            Graphics GH = Graphics.FromImage(BM as Image);

            //GH.CopyFromScreen(0, 0, 0, 0, FORM.Size);
            GH.CopyFromScreen(point, point2, BM.Size);

            BM.RotateFlip(RotateFlipType.Rotate90FlipXY);


            Rectangle bound = new Rectangle(x,y,width,height);


            this.DrawToBitmap(BM, bound);
            BM.Save(@"C:\Скриншот\" + screen + ".jpg");
        }

        public void print()
        {
            PrintDocument Document = new PrintDocument();
            Document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(Document_PrintPage);
            DialogResult result = printDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Document.Print();
            }
        }

        void Document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            e.Graphics.DrawImage(new Bitmap(@"C:\Скриншот\Скриншот.jpg"),e.MarginBounds); //Картинка на печать
        }

        public static bool rowCheck2 = false;
      

        private bool ПроверкаСтрок(string one, string two, string three, string four, string five, string six, bool tbR, CheckBox checs)
        {
            if (one == "" & two == "" & three == "" & four == "" & five == "" & six == "")
            { tbR = false; checs.Enabled = false; }
            else { tbR = true; checs.Enabled = true; }
            return tbR;
        }

        public static bool TB2R1 = false;
       
        
      
        private void ГлавнаяГруппа_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("keke2");
        }

        private void CoutnRel_KeyPress(object sender, KeyPressEventArgs e)
        {
            ТолькоЧисла(e);
        }

        private void CountCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            ТолькоЧисла(e);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (Таблица1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void CoutnRel_Leave(object sender, EventArgs e)
        {
            if (CoutnRel.Text != "")
             CountCheck.Text = ((Convert.ToDouble(CoutnRel.Text) * 0.2)).ToString("#").ToString();
        }

        private void Таблица2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (Таблица2.CurrentCell.ColumnIndex == 0 || Таблица2.CurrentCell.ColumnIndex == 1 || Таблица2.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }      


   

        private void Таблица2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (Form1.modeAQV == true)
                 AQ();
        }


        void AQ()
        {
            if (CoutnRel.Text == "" || CountCheck.Text == "") return;
            var QUALITY = "";

            #region
            //if (2 <= int.Parse(CoutnRel.Text) & 8 >= int.Parse(CoutnRel.Text))
            //    QUALITY = "A";
            //if (9 <= int.Parse(CoutnRel.Text) & 15 >= int.Parse(CoutnRel.Text))
            //    QUALITY = "B";
            //if (16 <= int.Parse(CoutnRel.Text) & 25 >= int.Parse(CoutnRel.Text))
            //    QUALITY = "C";
            //if (26 <= int.Parse(CoutnRel.Text) & 50 >= int.Parse(CoutnRel.Text))
            //    QUALITY = "D";
            //if (51 <= int.Parse(CoutnRel.Text) & 90 >= int.Parse(CoutnRel.Text))
            //    QUALITY = "E";
            //if (91 <= int.Parse(CoutnRel.Text) & 150 >= int.Parse(CoutnRel.Text))
            //    QUALITY = "F";

            //if (151 <= int.Parse(CoutnRel.Text) & 280 >= int.Parse(CoutnRel.Text))
            //    QUALITY = "G";
            #endregion

            if (281 <= int.Parse(CoutnRel.Text) & 500 >= int.Parse(CoutnRel.Text))
                QUALITY = "H";
            if (501 <= int.Parse(CoutnRel.Text) & 1200 >= int.Parse(CoutnRel.Text))
                QUALITY = "J";
            if (1201 <= int.Parse(CoutnRel.Text) & 3200 >= int.Parse(CoutnRel.Text))
                QUALITY = "K";
            if (3201 <= int.Parse(CoutnRel.Text) & 10000 >= int.Parse(CoutnRel.Text))
                QUALITY = "L";

            var error = 0;
            for (int i = 0; i < Таблица2.RowCount; i++)
            {
                if (Таблица2[2, i].Value != null)
                    if (Таблица2[2, i].Value != "")
                        if (Таблица2[7, i].Value.ToString() != "True")                   
                        error = error + int.Parse(Таблица2[2, i].Value.ToString());
               
            }

            StatusAqv.Visible = true;
            switch (QUALITY)
            {
                case "H":
                    if (error >= 2) { StatusAqv.Text = "Забраковано"; StatusAqv.ForeColor = Color.Red; AQL = false; return; }

                    break;
                case "J":
                    if (error >= 3) { StatusAqv.Text = "Забраковано"; StatusAqv.ForeColor = Color.Red; AQL = false; return; }

                    break;
                case "K":
                    if (error >= 4) { StatusAqv.Text = "Забраковано"; StatusAqv.ForeColor = Color.Red; AQL = false; return; }

                    break;
                case "L":
                    if (error >= 6) { StatusAqv.Text = "Забраковано"; StatusAqv.ForeColor = Color.Red; AQL = false; return; }
                    break;
            }

            StatusAqv.Text = "Партия принята"; StatusAqv.ForeColor = Color.Green; AQL = true;

        }

       
    }
}
