using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ModuleConnect;
using РеестрКонтроля_КЗ;
using РежимыРеестраКЗ;

namespace РеестрКонтроля_КЗ
{
    public partial class Сохранение : Form
    {
        List<bool> IsList { get; set; }        
        public Сохранение(List<bool> isList)
        {
            this.IsList = isList;
            InitializeComponent();
        }

        string sql, idName, idNamePaste, DateIdName, ДобавленРанее, ДобавленРанееИмя, idUser;

        void GeridUser()
        {
            idUser = Class1.LogginID(Form1.Loggin).ToString();
        }

        void Наименование()
        {
            sql = @"Use QA SELECT NameProduct  FROM [QA].[dbo].[Registry_ProjectDate] as dat left join Registry_Name as nam on dat.idNameProduct = nam.id where dat.idNameProduct = '" + idName + "'";
            ДобавленРанееИмя = Class1.SelectString(sql).ToString();
        }

        void ДатаНаименование()
        {
            sql = @"Use QA SELECT [Date]  FROM [QA].[dbo].[Registry_ProjectDate]  where idNameProduct = '" + idName + "'";
            ДобавленРанее = Class1.SelectStringDate(sql).ToString();
        }

        void ПроверкаДаты(int mode)
        {
            //sql = @"Use QA SELECT   [id]  FROM [QA].[dbo].[Registry_ProjectDate]  where idNameProduct = '" + idName + "' and idmode = '"+ mode +"'";
            sql = @"USE QA SELECT TOP (1) [id]        FROM [QA].[dbo].[Registry_ProjectDate]  where idNameProduct = '" + idName + "' and idmode = '" + mode + "'  order by id desc ";
            DateIdName = Class1.SelectStringInt(sql).ToString();

        }

        
       


        void update_pic_DP(int row, int num, string idus, string idnum,  string idname, int mode)
        {
          
            sql = @"update[QA].[dbo].[Registry_ DP_PH] set Descrption = N'"+ Photos.Массив[row] +"' where iduser = '"+ idus +"' and idnumpic = '" + num + "'   and idNameproject = '"+ idname +"' and idmode = '"+ mode +"'";
            Class1.SelectString(sql);
        }

        void описаниеКартинок(int num, int М,int mode)
        {
            sql = @"USE QA  insert into [QA].[dbo].[Registry_ DP_PH]  (iduser,idNameproject,idnumpic,Descrption,idmode) values ('" + idUser + "','" + idName + "', '" + num +"', N'" + Photos.Массив[М] + "','"+ mode +"')";
            Class1.SelectString(sql);
        }

        void добавлениеДаты(int mode)
        {

            sql = @"Use QA Insert into [QA].[dbo].[Registry_ProjectDate]  (idNameProduct,Date,idmode) Values ('" + idName + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '"+ mode +"')";
            Class1.SelectString(sql.ToString());
        }

        

        void Update_Паста (int mode)
        {
            sql = @"USE QA update[QA].[dbo].[Registry_PasteName]  set PasteName = '" + ГлавнаяФорма.Массив1[1] + "'  where  id = " + Поиск_Паста() + " and idmode = '" + mode + "'";
            Class1.SelectString(sql);

        }

        string Поиск_Паста()
        {
          sql = @" USE QA  SELECT idNamePaste  FROM [QA].[dbo].[Registry_SMT_Table1]  where idUser= '" + idUser + "' and idNameProduct = "+ idName + " and idRow = 1";
           return  Class1.SelectStringInt16(sql).ToString();
        }

        void ПроверкаИменованиеПАСТЫ(int mode)
        {
            sql = @"Use QA SELECT   [id]  FROM [QA].[dbo].[Registry_PasteName]  where PasteName = '" + ГлавнаяФорма.Массив1[1] + "' and idmode = '" + mode + "'";
            idNamePaste = Class1.SelectStringInt(sql).ToString();

        }

        void добавление_в_базуПАСТЫ(int mode)
        {

            sql = @"Use QA Insert into [QA].[dbo].[Registry_PasteName]  (PasteName,idmode) Values ('" + ГлавнаяФорма.Массив1[1] + "', '" + mode + "')";
            Class1.SelectString(sql.ToString());
        }


     void ПроверкаИменование(string Имя, int mode)
        {
            //sql = @"Use QA SELECT   [id]  FROM [QA].[dbo].[Registry_Name]  where NameProduct = '" + Имя + "' and idmode = '" + mode +"'";
            sql = @"USE QA SELECT TOP (1) [id]     FROM [QA].[dbo].[Registry_Name]  where NameProduct = '" + Имя + "' and idMode = '" + mode + "'  order by id desc ";
           Form1.key =  idName = Class1.SelectStringInt(sql).ToString();

        }
        
        void ПроверкаНаименованиеUpdate(int mode)
        {
            sql = @"USE QA SELECT idNameProduct  FROM [QA].[dbo].[Registry_ProjectDate] as p  left join Registry_Name as na on p.idNameProduct = na.id
                     where  na.id = '" + Form1.key + "' and p.idmode = '" + mode + "'";
            idName = Class1.SelectStringInt16(sql).ToString();
        }

        private void Сохранение_Load(object sender, EventArgs e)
        {
            РежимСохранение();

        }

        private void РежимСохранение()
        {
            if (Form1.Новый_отчёт == true)
            {
                Сохранить.Text = "Сохранить";
            }
            else if (Form1.ОтчетШаблон == true)

            { Сохранить.Text = "Сохранить"; }

            else
            {
                Сохранить.Text = "Изменить";

            }
        }

        void Сохранение_числа_проверенных(int mode)
        {
            string sql;
            sql = @" USE QA insert into [QA].[dbo].[Registry_TableCounter]  ([idName]      ,[iduser]      ,[CountForRelease]      ,[CountCheckRel],[DescpPR], idmode)
                  values
                  ('" + idName + "','" + idUser + "','" + ГлавнаяФорма.Массив12[0] + "','" + ГлавнаяФорма.Массив12[1] + "', '"+ ГлавнаяФорма.Массив12[2] + "', '"+ mode +"')";
            Class1.SelectString(sql);
        }

        void Update_Подписи(int row, int mas, int mas2, int mode)
        {
            string sql;
            sql = @" USE QA update [QA].[dbo].[Registry_signature]  set NameSignature = '" + ГлавнаяФорма.Массив4[mas] + "', Date = '" + ГлавнаяФорма.Массив4[mas2] + "'  where idRow = '"+ row +"' and idUser = '"+ idUser +"' and idNameProduct ='"+ idName +"' and idmode = '"+ mode +"'";
            Class1.SelectString(sql);
        }

        void Update_Подписи_pole(string переменная, int idrow,int mode)
        {
            string sql;
            sql = @" USE QA update [QA].[dbo].[Registry_signature]  set pole1 = '" + переменная + "' where idRow = '" + idrow  + "' and idUser = '" + idUser + "' and idNameProduct ='" + idName + "' and idmode = '" + mode + "'";
            Class1.SelectString(sql);
        }



        void Update_Date(int mode)
        {
            sql = @"USE QA  update[QA].[dbo].[Registry_ProjectDate]  set Date = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'  where idNameProduct = '" + idName + "' and idmode = '"+ mode +"'";
            Class1.SelectString(sql);
        }

        void Upate_checks()
        {
            var ch = IsList[0] == true ? 1 : 0;
            var ch1 = IsList[1] == true ? 1 : 0;
            var ch2 = IsList[2] == true ? 1 : 0;
            var ch3 = IsList[3] == true ? 1 : 0;

            sql = $@"USE QA update [QA].[dbo].[Registry_Name]  set [IsTermo] = {ch},[IsElProtocol] = {ch1},[IsEtalon] = {ch2}, [IsAssemblyDraw] = {ch3}  where id = {idName}";
            Class1.SelectString(sql);
        }

        void Update_Counter(int mode)
        {
            string sql;
            sql = @"USE QA  update [QA].[dbo].[Registry_TableCounter]  set CountCheckRel = '" + ГлавнаяФорма.Массив12[1] + "', CountForRelease = '" + ГлавнаяФорма.Массив12[0] + "', DescpPR = '"+ ГлавнаяФорма.Массив12[2] + "'  where idName = '" + idName + "' and iduser = '" + idUser + "' and idmode = '" + mode +"'";
            Class1.SelectString(sql);
        }

        void Updatename()
        {
            sql = @" USE QA  update [QA].[dbo].[Registry_Name]  set NameProduct = '" + ГлавнаяФорма.Массив1[0] + "'  where id = " + idName + "";
            Class1.SelectString(sql);
        }

        void добавление_в_базу(int mode)
        {
            var ch = IsList[0] == true ? 1 : 0;
            var ch1 = IsList[1] == true ? 1 : 0;
            var ch2 = IsList[2] == true ? 1 : 0;
            var ch3 = IsList[3] == true ? 1 : 0;

            sql = $@"Use QA Insert into [QA].[dbo].[Registry_Name] (NameProduct,idMode,Aqv,[IsTermo],[IsElProtocol],[IsEtalon],[IsAssemblyDraw]) Values 
                ('{ГлавнаяФорма.Массив1[0]}', '{mode}', '{Form1.modeAQV}', {ch},{ch1},{ch2},{ch3} )";
            Class1.SelectString(sql.ToString());
        }

        void Таблица2Update(int mode)
        {
            for (int i = 0; i < 20; i++)
            {
                sql = @" USE QA update [QA].[dbo].[Registry_SMT_Table2] 
                set CountForCheck = '"+ ГлавнаяФорма.МногомерныйМассив2[i, 0] + "', CountCheck = '" + ГлавнаяФорма.МногомерныйМассив2[i,1] + "', CountDefects = '" + ГлавнаяФорма.МногомерныйМассив2[i, 2] + "',DefectCode = '" + ГлавнаяФорма.МногомерныйМассив2[i, 3] + "', Position = '" + ГлавнаяФорма.МногомерныйМассив2[i, 4] + "', Description = '" + ГлавнаяФорма.МногомерныйМассив2[i, 5] + "', Rem = '" + ГлавнаяФорма.МногомерныйМассив2Бул[i,0] + "', [AqvDefectfixed] = '" + ГлавнаяФорма.МногомерныйМассив2[i, 7] + "'   " +
                "where idUser = '" + idUser + "' and idNameProduct = '" + idName + "' and idRow = '" + i +"' and idmode = '"+ mode +"'";
                Class1.SelectString(sql);
            }
        }


        void update_Таблица1(int mode)
        {
            for (int i = 0; i < 5; i++)
            {

                sql = @"  USE QA update [QA].[dbo].[Registry_SMT_Table1]  set Line = '" + ГлавнаяФорма.МногомерныйМассив1[i,0] + "' ,Lot = '" + ГлавнаяФорма.МногомерныйМассив1[i, 1] + "', Spec = '" + ГлавнаяФорма.МногомерныйМассив1[i,2] + "' ,   idTypePaste = '" + ГлавнаяФорма.Paste + "' ,countProd = '" + ГлавнаяФорма.МногомерныйМассив1[i, 3] + "' , CountTest = '" + ГлавнаяФорма.МногомерныйМассив1[i, 4] + "' , CountPassTest = '" + ГлавнаяФорма.МногомерныйМассив1[i, 5] + "' ,CountFailTest = '" + ГлавнаяФорма.МногомерныйМассив1[i, 6] + "', FPY = '" + ГлавнаяФорма.МногомерныйМассив1[i, 7] + "', Defects = '" + ГлавнаяФорма.МногомерныйМассив1[i, 8] + "', Decription = '" + ГлавнаяФорма.МногомерныйМассив1[i, 9] + "'" +
                        " where idRow = " + i + " and idUser = " + idUser + " and idNameProduct = " + idName + " and idmode = '" + mode + "' ";
            //Clipboard.SetText(sql);
            Class1.SelectString(sql);
            }
        }

        void Добавление_в_главную_таблицу( string dateidName, string idusers, string namePaste, int Paste, string idNames, int mode)
        {
            for (int i = 0; i < 5; i++)
            {
              
                    sql = @" USE QA  Insert into [QA].[dbo].[Registry_SMT_Table1]  ([idRow]      ,[idDateCreate]      ,[idUser]      ,[idNamePaste]      ,[idTypePaste]      ,[idNameProduct]      ,[Line]
                ,[Lot]      ,[Spec]      ,[countProd]      ,[CountTest]      ,[CountPassTest]      ,[CountFailTest]      ,[FPY]      ,[Defects]      ,[Decription], [idmode]) 
                VALUES
	                ('" + i + "','" + dateidName + "','" + idusers + "','" + namePaste + "'," +
                  "'" + Paste + "','" + idNames + "', '" +  ГлавнаяФорма.МногомерныйМассив1[i,0]  + "','" + ГлавнаяФорма.МногомерныйМассив1[i, 1] + "'," +
                  "'" + ГлавнаяФорма.МногомерныйМассив1[i, 2] + "','" + ГлавнаяФорма.МногомерныйМассив1[i, 3] + "'," +
                  "'" + ГлавнаяФорма.МногомерныйМассив1[i, 4] + "','" + ГлавнаяФорма.МногомерныйМассив1[i, 5] + "'," +
                  "'" + ГлавнаяФорма.МногомерныйМассив1[i, 6] + "','" + ГлавнаяФорма.МногомерныйМассив1[i, 7] + "'," +
                  "'" + ГлавнаяФорма.МногомерныйМассив1[i, 8] + "','" + ГлавнаяФорма.МногомерныйМассив1[i, 9] + "', '"+ mode +"')";
                Class1.SelectString(sql);
                
            }
            
        }

        void Добавление_вторая_Таблица( string dateidName, string idusers, string namePaste, int Paste, string idNames,int mode) //Сохранение данных с 1 таблицы 1 строки
        {

            for (int i = 0; i < 20; i++)
            {
                sql = @"  Use QA insert into [QA].[dbo].[Registry_SMT_Table2]
        ([idRow]      ,[idDateCreate]      ,[idUser]      ,[idNamePaste]      ,[idTypePaste]      ,[idNameProduct]      ,[CountForCheck]      ,[CountCheck]
      ,[CountDefects]      ,[DefectCode]      ,[Position]      ,[Description]    ,[Rem], [idmode],[AqvDefectfixed])
	        Values
	        ('" + i + "','" + dateidName + "','" + idusers + "','" + namePaste + "','" + Paste + "', '" + idNames + "'," +
         "'" + ГлавнаяФорма.МногомерныйМассив2[i,0] + "','" + ГлавнаяФорма.МногомерныйМассив2[i, 1] + "'" +
         ",'" + ГлавнаяФорма.МногомерныйМассив2[i, 2] + "','" + ГлавнаяФорма.МногомерныйМассив2[i, 3] + "','" + ГлавнаяФорма.МногомерныйМассив2[i, 4] + "'," +
         "'" + ГлавнаяФорма.МногомерныйМассив2[i, 5] + "','" + ГлавнаяФорма.МногомерныйМассив2Бул[i,0] + "', '" + mode + "',"+ ГлавнаяФорма.МногомерныйМассив2[i, 7] + ")";
                Class1.SelectString(sql);
            }
        }

        void СохранениеКартинок(int num, string pic,int mode)
        {
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            string loadPH = @"\\gusev.int\fs\cts\ДСНТ\Exchange\ФотографииКЗ\" + num + "-" + idUser + "-" + idName + " "+ dateTimePicker1.Value.ToString("yyyy-MM-dd hh-ss") +".png";
            try
            {

            if (pic != "")
            {
                    myImageCodecInfo = GetEncoderInfo("image/jpeg");
                    myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    myEncoderParameters = new EncoderParameters(1);
                    myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    Bitmap BM = new Bitmap(pic); BM.Save(loadPH, myImageCodecInfo, myEncoderParameters);
                sql = @" USE QA insert into [QA].[dbo].[Registry_Photos]  (idNameProject,idUser,idMode,pic1,numPic) values ('" + idName + "', '" + idUser + "', '" + mode + "', '" + loadPH + "', '" + num + "')";
                Class1.SelectString(sql);
            }
            else
            {
                sql = @" USE QA insert into [QA].[dbo].[Registry_Photos]  (idNameProject,idUser,idMode,pic1,numPic) values ('" + idName + "', '" + idUser + "', '" + Form1.mode + "', '', '" + num + "')";
                Class1.SelectString(sql);
            }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                //Clipboard.SetText(e.ToString());
            }
        }

        void updateКартинов( string name, string idus, int mode, int num, string pict )
        {
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            string loadPH = @"\\gusev.int\fs\cts\ДСНТ\Exchange\ФотографииКЗ\" + num + "-" + idUser + "-" + idName + "-" + dateTimePicker1.Value.ToString("yyyy-MM-dd hh-ss") + ".png";
            try
            {

            if (pict != "")
            {
                                  
                  

                    myImageCodecInfo = GetEncoderInfo("image/jpeg");
                    myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    myEncoderParameters = new EncoderParameters(1);
                    myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    Bitmap BM = new Bitmap(pict);
                    BM.Save(loadPH, myImageCodecInfo, myEncoderParameters);

                    
                sql = @"USE QA   update [QA].[dbo].[Registry_Photos]  set pic1= '" + loadPH + "' " +
                "where idNameProject = '" + name + "' and idUser = '" + idus + "' and idMode = '" + mode + "' and numPic = '" + num + "'";
                Class1.SelectString(sql);
                    
            }
            
                else if (pict == "") 
                {
                    File.Delete(loadPH);
                    sql = @"USE QA   update [QA].[dbo].[Registry_Photos]  set pic1= '' " +
               "where idNameProject = '" + name + "' and idUser = '" + idus + "' and idMode = '" + mode + "' and numPic = '" + num + "'";
                    Class1.SelectString(sql);

                }

            }
            catch (Exception e)
            {
               MessageBox.Show(e.ToString());
            }

        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        void ДобавлениеПодписей (int row , int mas,int mas2,int mode, string pole, string forpole)
            {
           
                sql = @"  Use QA insert into  [QA].[dbo].[Registry_signature]  (idRow,idUser,idNameProduct,NameSignature,[Date],idmode "+ pole + ") values "+
                 "      ('" + row + "', '" + idUser + "', '" + idName + "','" + ГлавнаяФорма.Массив4[mas] + "', '"+ ГлавнаяФорма.Массив4[mas2] + "', '"+ mode + "' " + forpole + ") ";
                Class1.SelectString(sql);
            
        }

        private void Сохранить_Click_1(object sender, EventArgs e)
        {
            РежимСохранениеПроекта();
            string status;
            if (ГлавнаяФорма.AQL)
                status = "Партия Принята";
            else status = "Забраковано";


            if (checkBox1.Checked == true)
                if (Form1.modeAQV == true) { Class1.ОтправкаСообщения(ГлавнаяФорма.Массив1[0], "Статус Отчёта "+ status +""); return; }
                else Class1.ОтправкаСообщения(ГлавнаяФорма.Массив1[0]);
               
           
           
           
                
           
           
        }

        private void РежимСохранениеПроекта()
        {
            GeridUser();
            if (Form1.Новый_отчёт == true) //Условие если новый проект, то  сохраняем запросом INSERT INTO
            {
                Form1.Новый_отчёт = false;
                СохранениПроектаSMT(Form1.mode);
            }

            else if (Form1.ОтчетШаблон == true)
            {
                Form1.Новый_отчёт = false;
                СохранениПроектаSMT(Form1.mode);
                Form1.ОтчетШаблон = false;

            }

            else //Условие если созданный проект, то сохраняем запросом UPDATE
            {
                МетодUpdateSMT(Form1.mode);

            }
            if (Form1.modeAQV == true)
                     addLog();


            this.Close();
        }

        void addLog()
        {
            var SQL = " use QA insert into[QA].[dbo].[Registry_Log]   (idNameProject, Status, date) values('"+ idName + "','"+ ГлавнаяФорма.AQL + "', CURRENT_TIMESTAMP)";
            Class1.SelectString(SQL);
        }
        //private void РежимСохранениеПроектаFAS()
        //{
        //    GeridUser();
        //    if (Form1.Новый_отчёт == true) //Условие если новый проект, то  сохраняем запросом INSERT INTO
        //    {
        //        Form1.Новый_отчёт = false;
        //        //СохранениПроектаFAS();
        //    }
        //    else //Условие если созданный проект, то сохраняем запросом UPDATE
        //    {
        //        //МетодUpdateFAS();

        //    }
        //    this.Close();
        //}

        void МетодЗагрузкткартинок(int mode)
        {
            if (Photos.bl1 == true) updateКартинов(idName,idUser,mode,1,Photos.ppic);
            if (Photos.bl2 == true) updateКартинов(idName, idUser, mode, 2, Photos.ppic2);
            if (Photos.bl3 == true) updateКартинов(idName, idUser, mode, 3, Photos.ppic3);
            if (Photos.bl4 == true) updateКартинов(idName, idUser, mode, 4, Photos.ppic4);
            if (Photos.bl5 == true) updateКартинов(idName, idUser, mode, 5, Photos.ppic5);
            if (Photos.bl6 == true) updateКартинов(idName, idUser, mode, 6, Photos.ppic6);
            if (Photos.bl7 == true) updateКартинов(idName, idUser, mode, 7, Photos.ppic7);
            if (Photos.bl8 == true) updateКартинов(idName, idUser, mode, 8, Photos.ppic8);
            if (Photos.bl9 == true) updateКартинов(idName, idUser, mode, 9, Photos.ppic9);
            if (Photos.bl10 == true) updateКартинов(idName, idUser, mode, 10, Photos.ppic10);
            if (Photos.bl11 == true) updateКартинов(idName, idUser, mode, 11, Photos.ppic11);
            if (Photos.bl12 == true) updateКартинов(idName, idUser, mode, 12, Photos.ppic12);
            if (Photos.bl13 == true) updateКартинов(idName, idUser, mode, 13, Photos.ppic13);
            if (Photos.bl14 == true) updateКартинов(idName, idUser, mode, 14, Photos.ppic14);
            if (Photos.bl15 == true) updateКартинов(idName, idUser, mode, 15, Photos.ppic15);
            if (Photos.bl16 == true) updateКартинов(idName, idUser, mode, 16, Photos.ppic16);
            if (Photos.bl17 == true) updateКартинов(idName, idUser, mode, 17, Photos.ppic17);
            if (Photos.bl18 == true) updateКартинов(idName, idUser, mode, 18, Photos.ppic18);
            if (Photos.bl19 == true) updateКартинов(idName, idUser, mode, 19, Photos.ppic19);
            if (Photos.bl20 == true) updateКартинов(idName, idUser, mode, 20, Photos.ppic20);
           

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void МетодUpdateSMT(int mode)
        {

            Update_проекта(mode);
            Update_Паста(mode);
            Update_Date(mode);
            Upate_checks();

            update_Таблица1(mode);
                   
            Update_Counter(mode);

            Таблица2Update( mode);
          
            Update_Подписи(1, 0, 4,mode);
            Update_Подписи(2, 1, 5,mode);
            Update_Подписи(3, 2, 6,mode);
            Update_Подписи(4, 3, 7,mode);

            Update_Подписи_pole(ГлавнаяФорма.Массив1[2], 3, mode);
            Update_Подписи_pole(ГлавнаяФорма.Массив1[3], 4, mode);

            if (ГлавнаяФорма.buttonPhoto == true)
            {  for (int i = 1; i < 21; i++)  {  update_pic_DP(i - 1,i,idUser,idName,idName,mode);   } }

            МетодЗагрузкткартинок(mode);

            MessageBox.Show("Проект изменен","",MessageBoxButtons.OK,MessageBoxIcon.Information);



        }

        void Update_проекта(int mode)
        {
          
            ПроверкаНаименованиеUpdate(mode);
            if (idName == 0.ToString()) { } else { Updatename(); }
            ПроверкаИменованиеПАСТЫ(mode);

        }


       void СохранениПроектаSMT(int mode)
        {


            //ПроверкаИменование(ГлавнаяФорма.Массив1[0], mode);
            //if (idName == 0.ToString()) { добавление_в_базу(mode); ПроверкаИменование(ГлавнаяФорма.Массив1[0], mode); }

            добавление_в_базу(mode);
            ПроверкаИменование(ГлавнаяФорма.Массив1[0], mode);

            ПроверкаИменованиеПАСТЫ(mode);
            if (idNamePaste == 0.ToString()) { добавление_в_базуПАСТЫ(mode); ПроверкаИменованиеПАСТЫ(mode); }

            //ПроверкаДаты(mode);
            //if (DateIdName == 0.ToString())добавлениеДаты(mode); ПроверкаДаты(mode);

            добавлениеДаты(mode); ПроверкаДаты(mode);


            Добавление_в_главную_таблицу(DateIdName, idUser, idNamePaste, ГлавнаяФорма.Paste, idName,mode);


            Сохранение_числа_проверенных(mode);

            Добавление_вторая_Таблица( DateIdName, idUser, idNamePaste, ГлавнаяФорма.Paste, idName, mode);
          
            ДобавлениеПодписей(1, 0, 4,mode,"","");
            ДобавлениеПодписей(2, 1, 5,mode,"","");
            ДобавлениеПодписей(3, 2, 6,mode,",pole1",", '"+ ГлавнаяФорма.Массив1[2] +"' ");
            ДобавлениеПодписей(4, 3, 7,mode, ",pole1", ", '" + ГлавнаяФорма.Массив1[3] + "' ");

            for (int i = 1; i < 21; i++)
            {
                описаниеКартинок(i, i - 1,mode);
            }

            Картинки(mode);
            

        }


        void ШаблонМетод(string pic, string pic2, int mode, int num)
        {
            if (pic != "")
            {
                sql = @" USE QA insert into [QA].[dbo].[Registry_Photos]  (idNameProject,idUser,idMode,pic1,numPic) values ('" + idName + "', '" + idUser + "', '" + mode + "', '" + pic + "', '" + num + "')";
                Class1.SelectString(sql);
                return;
            }
            else 
            {
                СохранениеКартинок(num, pic2, mode);
            }
            
            
        }

        void Шаблонсохранение()
        {
            
        }

        private void Картинки(int mode)
        {
            if (Form1.ОтчетШаблон == true)
            {
                ШаблонМетод(Photos.pic, Photos.ppic, mode, 1);
                ШаблонМетод(Photos.pic2, Photos.ppic2, mode, 2);
                ШаблонМетод(Photos.pic3, Photos.ppic3, mode, 3);
                ШаблонМетод(Photos.pic4, Photos.ppic4, mode, 4);
                ШаблонМетод(Photos.pic5, Photos.ppic5, mode, 5);
                ШаблонМетод(Photos.pic6, Photos.ppic6, mode, 6);
                ШаблонМетод(Photos.pic7, Photos.ppic7, mode, 7);
                ШаблонМетод(Photos.pic8, Photos.ppic8, mode, 8);
                ШаблонМетод(Photos.pic9, Photos.ppic9, mode, 9);
                ШаблонМетод(Photos.pic10, Photos.ppic10, mode, 10);
                ШаблонМетод(Photos.pic11, Photos.ppic11, mode, 11);
                ШаблонМетод(Photos.pic12, Photos.ppic12, mode, 12);
                ШаблонМетод(Photos.pic13, Photos.ppic13, mode, 13);
                ШаблонМетод(Photos.pic14, Photos.ppic14, mode, 14);
                ШаблонМетод(Photos.pic15, Photos.ppic15, mode, 15);
                ШаблонМетод(Photos.pic16, Photos.ppic16, mode, 16);
                ШаблонМетод(Photos.pic17, Photos.ppic17, mode, 17);
                ШаблонМетод(Photos.pic18, Photos.ppic18, mode, 18);
                ШаблонМетод(Photos.pic19, Photos.ppic19, mode, 19);
                ШаблонМетод(Photos.pic20, Photos.ppic20, mode, 20);

            }
            else if (Form1.ОтчетШаблон == false)
            {
                СохранениеКартинок(1, Photos.ppic, mode);
                СохранениеКартинок(2, Photos.ppic2, mode);
                СохранениеКартинок(3, Photos.ppic3, mode);
                СохранениеКартинок(4, Photos.ppic4, mode);
                СохранениеКартинок(5, Photos.ppic5, mode);
                СохранениеКартинок(6, Photos.ppic6, mode);
                СохранениеКартинок(7, Photos.ppic7, mode);
                СохранениеКартинок(8, Photos.ppic8, mode);
                СохранениеКартинок(9, Photos.ppic9, mode);
                СохранениеКартинок(10, Photos.ppic10, mode);
                СохранениеКартинок(11, Photos.ppic11, mode);
                СохранениеКартинок(12, Photos.ppic12, mode);
                СохранениеКартинок(13, Photos.ppic13, mode);
                СохранениеКартинок(14, Photos.ppic14, mode);
                СохранениеКартинок(15, Photos.ppic15, mode);
                СохранениеКартинок(16, Photos.ppic16, mode);
                СохранениеКартинок(17, Photos.ppic17, mode);
                СохранениеКартинок(18, Photos.ppic18, mode);
                СохранениеКартинок(19, Photos.ppic19, mode);
                СохранениеКартинок(20, Photos.ppic20, mode);
            }

        }
    }
}
