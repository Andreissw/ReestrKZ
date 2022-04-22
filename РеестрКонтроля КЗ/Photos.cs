using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using РеестрКонтроля_КЗ;
//using ModuleConnect;
using РежимыРеестраКЗ;
using System.IO;

namespace РеестрКонтроля_КЗ
{
    public partial class Photos : Form
    {
        public Photos()
        {
            InitializeComponent();
        }

        void НедоступностьМетод()
        {
            недоступность(true, TB1, Pict1);
            недоступность(true, TB2, Pict2);
            недоступность(true, TB3, Pict3);
            недоступность(true, TB4, Pict4);
            недоступность(true, TB5, Pict5);
            недоступность(true, TB6, Pict6);
            недоступность(true, TB7, Pict7);
            недоступность(true, TB8, Pict8);
            недоступность(true, TB9, Pict9);
            недоступность(true, TB10, Pict10);
            недоступность(true, TB11, Pict11);
            недоступность(true, TB12, Pict12);
            недоступность(true, TB13, Pict13);
            недоступность(true, TB14, Pict14);
            недоступность(true, TB15, Pict15);
            недоступность(true, TB16, Pict16);
            недоступность(true, TB17, Pict17);
            недоступность(true, TB18, Pict18);
            недоступность(true, TB19, Pict19);
            недоступность(true, TB20, Pict20);
        }

        void ЗапускТекстбокса(TextBox tb, int row)
        {
            try
            { tb.Text = Массив[row];  }  catch (Exception)  { }
        }

        void Метод_Запуск(PictureBox pict,string pic)
        {
            try
            { pict.Image = new Bitmap(pic);   }   catch (Exception)  {}
           
        }

      

        void Запуск()
        {
            if (bl1 == true)Метод_Запуск(Pict1, ppic); //Если в существующем проекте изменил картинку, то выполняется эта строчка 
            if (bl2 == true)Метод_Запуск(Pict2, ppic2);
            if (bl3 == true)Метод_Запуск(Pict3, ppic3);
            if (bl4 == true) Метод_Запуск(Pict4, ppic4);
            if (bl5 == true) Метод_Запуск(Pict5, ppic5);
            if (bl6 == true) Метод_Запуск(Pict6, ppic6);
            if (bl7 == true) Метод_Запуск(Pict7, ppic7);
            if (bl8 == true) Метод_Запуск(Pict8, ppic8);
            if (bl9 == true) Метод_Запуск(Pict9, ppic9);
            if (bl10 == true) Метод_Запуск(Pict10, ppic10);
            if (bl11 == true) Метод_Запуск(Pict11, ppic11);
            if (bl12 == true) Метод_Запуск(Pict12, ppic12);
            if (bl13 == true) Метод_Запуск(Pict13, ppic13);
            if (bl14 == true) Метод_Запуск(Pict14, ppic14);
            if (bl15 == true) Метод_Запуск(Pict15, ppic15);
            if (bl16 == true) Метод_Запуск(Pict16, ppic16);
            if (bl17 == true) Метод_Запуск(Pict17, ppic17);
            if (bl18 == true) Метод_Запуск(Pict18, ppic18);
            if (bl19 == true) Метод_Запуск(Pict19, ppic19);
            if (bl20 == true) Метод_Запуск(Pict20, ppic20);

            if (bl1 == false) Метод_Запуск(Pict1, pic);//Если в существующем проекте картинку не трогали и она оасталась какая была, то выполняется эта строчка 
            if (bl2 == false) Метод_Запуск(Pict2, pic2);
            if (bl3 == false) Метод_Запуск(Pict3, pic3);
            if (bl4 == false) Метод_Запуск(Pict4, pic4);
            if (bl5 == false) Метод_Запуск(Pict5, pic5);
            if (bl6 == false) Метод_Запуск(Pict6, pic6);
            if (bl7 == false) Метод_Запуск(Pict7, pic7);
            if (bl8 == false) Метод_Запуск(Pict8, pic8);
            if (bl9 == false) Метод_Запуск(Pict9, pic9);
            if (bl10 == false) Метод_Запуск(Pict10, pic10);
            if (bl11 == false) Метод_Запуск(Pict11, pic11);
            if (bl12 == false) Метод_Запуск(Pict12, pic12);
            if (bl13 == false) Метод_Запуск(Pict13, pic13);
            if (bl14 == false) Метод_Запуск(Pict14, pic14);
            if (bl15 == false) Метод_Запуск(Pict15, pic15);
            if (bl16 == false) Метод_Запуск(Pict16, pic16);
            if (bl17 == false) Метод_Запуск(Pict17, pic17);
            if (bl18 == false) Метод_Запуск(Pict18, pic18);
            if (bl19 == false) Метод_Запуск(Pict19, pic19);
            if (bl20 == false) Метод_Запуск(Pict20, pic20);


        }

        void ЗапускТекстБокса()
        {
            ЗапускТекстбокса(TB1, 0);
            ЗапускТекстбокса(TB2, 1);
            ЗапускТекстбокса(TB3, 2);
            ЗапускТекстбокса(TB4, 3);
            ЗапускТекстбокса(TB5, 4);
            ЗапускТекстбокса(TB6, 5);
            ЗапускТекстбокса(TB7, 6);
            ЗапускТекстбокса(TB8, 7);
            ЗапускТекстбокса(TB9, 8);
            ЗапускТекстбокса(TB10, 9);
            ЗапускТекстбокса(TB11, 10);
            ЗапускТекстбокса(TB12, 11);
            ЗапускТекстбокса(TB13, 12);
            ЗапускТекстбокса(TB14, 13);
            ЗапускТекстбокса(TB15, 14);
            ЗапускТекстбокса(TB16, 15);
            ЗапускТекстбокса(TB17, 16);
            ЗапускТекстбокса(TB18, 17);
            ЗапускТекстбокса(TB19, 18);
            ЗапускТекстбокса(TB20, 19);

        }

        string ЗагрузкаСБазы(PictureBox pic, TextBox tb, int num, int mode)
        {
            if (Загрузка_картинок(Form1.Модель, Form1.idus, mode, num) != "")

                //pic.Image = new Bitmap(Загрузка_картинок(Form1.Модель, Form1.idus, "1", num));
            pic.Load(Загрузка_картинок(Form1.Модель, Form1.idus, mode, num));
                
            
            tb.Text = зАгрузкаТекста(Form1.Модель, Form1.idus, mode, num);
            
            return Загрузка_картинок(Form1.Модель, Form1.idus, mode, num); 

        }

        void МетодЗагрузки(int mode)
        {
          pic =  ЗагрузкаСБазы(Pict1, TB1,1, mode);
          pic2 =  ЗагрузкаСБазы(Pict2, TB2,2,mode);
          pic3 =  ЗагрузкаСБазы(Pict3, TB3,3, mode);
          pic4 =  ЗагрузкаСБазы(Pict4, TB4,4, mode);
          pic5 =  ЗагрузкаСБазы(Pict5, TB5,5, mode);
          pic6 =  ЗагрузкаСБазы(Pict6, TB6, 6, mode);
          pic7 =   ЗагрузкаСБазы(Pict7, TB7, 7, mode);
          pic8 =  ЗагрузкаСБазы(Pict8, TB8, 8, mode);
          pic9 =  ЗагрузкаСБазы(Pict9, TB9, 9, mode);
          pic10 =  ЗагрузкаСБазы(Pict10, TB10, 10, mode);
          pic11 =  ЗагрузкаСБазы(Pict11, TB11, 11, mode);
          pic12 =  ЗагрузкаСБазы(Pict12, TB12, 12,mode);
          pic13 =  ЗагрузкаСБазы(Pict13, TB13, 13,mode);
          pic14 =  ЗагрузкаСБазы(Pict14, TB14, 14,mode);
          pic15 =  ЗагрузкаСБазы(Pict15, TB15, 15,mode);
          pic16 =  ЗагрузкаСБазы(Pict16, TB16, 16,mode);
          pic17 =  ЗагрузкаСБазы(Pict17, TB17, 17,mode);
          pic18 =  ЗагрузкаСБазы(Pict18, TB18, 18,mode);
          pic19 =  ЗагрузкаСБазы(Pict19, TB19, 19,mode);
          pic20 =  ЗагрузкаСБазы(Pict20, TB20, 20, mode);

        }


        void Картинос()
        {
           
        }

        private void Photos_Load(object sender, EventArgs e)
        {
            ГлавнаяФорма.checkform = true;
            if (Form1.Новый_отчёт == true) //Когда создается новый отчет 
            {
                Запуск();
                ЗапускТекстБокса();
                НедоступностьМетод();

            }
            else if (Form1.Новый_отчёт == false) //При создании шаблона или запуска готового проекта
            {
                if (ГлавнаяФорма.k == 0)
                {
                    МетодЗагрузки(Form1.mode);
                    НедоступностьМетод();
                    ГлавнаяФорма.k++;
                }
                else                                //Когда проект открыт и в форму фотографий заходят больше одного раза
                {
                    Запуск();
                    ЗапускТекстБокса();
                    НедоступностьМетод();
                }
               
            }
            if (Form1.Отчет == true)
            {
                TB1.ReadOnly = true;
                TB2.ReadOnly = true;
                TB3.ReadOnly = true;
                TB4.ReadOnly = true;
                TB5.ReadOnly = true;
                TB6.ReadOnly = true;
                TB7.ReadOnly = true;
                TB8.ReadOnly = true;
                TB9.ReadOnly = true;
                TB1.ReadOnly = true;
                TB10.ReadOnly = true;
                TB11.ReadOnly = true;
                TB12.ReadOnly = true;
                TB13.ReadOnly = true;
                TB14.ReadOnly = true;
                TB15.ReadOnly = true;
                TB16.ReadOnly = true;
                TB17.ReadOnly = true;
                TB18.ReadOnly = true;
                TB19.ReadOnly = true;
                TB20.ReadOnly = true;
                LoadBut1.Visible = false;
                LoadBut2.Visible = false;
                LoadBut3.Visible = false;
                LoadBut4.Visible = false;
                LoadBut5.Visible = false;
                LoadBut6.Visible = false;
                LoadBut7.Visible = false;
                LoadBut8.Visible = false;
                LoadBut9.Visible = false;
                LoadBut10.Visible = false;
                LoadBut11.Visible = false;
                LoadBut12.Visible = false;
                LoadBut13.Visible = false;
                LoadBut14.Visible = false;
                LoadBut15.Visible = false;
                LoadBut16.Visible = false;
                LoadBut17.Visible = false;
                LoadBut18.Visible = false;
                LoadBut19.Visible = false;
                LoadBut20.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
            }

            
            groupPage(GR1, GR2, GR3, GR4, GR5);
            this.Text = "Photos" + " " + ГлавнаяФорма.LogName;
            button12.Enabled = false;
            var sizen = new Size(939, 890);
            var points = new Size(0, 0);
            this.Size = Size.Add(points, sizen);
            
        }

        string зАгрузкаТекста(string namePR, string idus, int mode, int numpic)
        {
            string sql;
            sql = @"USE QA SELECT Descrption  FROM [QA].[dbo].[Registry_ DP_PH] smt 
            inner join Registry_Name as nm on smt.idNameProject = nm.id
            inner join Registry_ProjectDate as PR on smt.idNameProject = PR.idNameProduct
                where iduser = '" + idus + "' and idnumpic = '" + numpic + "' and smt.idmode = '" + mode + "' and nm.id = '" + Form1.key + "'";
            return Class1.SelectString(sql).ToString();
        }

        string Загрузка_картинок (string namePR, string idus, int mode, int numpic) //Находит путь к картинке

        {

            string sql;
            sql = @"  USE QA SELECT   [pic1]      FROM [QA].[dbo].[Registry_Photos]  smt 
                inner join Registry_Name as nm on smt.idNameProject = nm.id
                inner join Registry_ProjectDate as PR on smt.idNameProject = PR.idNameProduct
                where  idUser = '" + idus + "' and smt.idMode = '"+ mode + "' and numPic = '" + numpic + "' and nm.id = '" + Form1.key + "'";
            return Class1.SelectString(sql).ToString();

            }



        void groupPage(GroupBox Group,  GroupBox grVisFalse, GroupBox grVisFalse2,  GroupBox grVisFalse4,  GroupBox grVisFalse5, int points = 0, int x = 12, int y = 58)  // Установка локации групбокса
        {
            grVisFalse.Visible = false;
            grVisFalse2.Visible = false;
            grVisFalse4.Visible = false;
            grVisFalse5.Visible = false;
            Point point = new Point(points);
            Size point2 = new Size(x,y);
            Size pointSize = new Size(0, 0);
            Size pointSize2 = new Size(869, 787);
            Group.Visible = true;

            Group.Location = Point.Add(point, point2);
            Group.Size = Size.Add(pointSize, pointSize2);
        }

        public static string pic, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, pic11, pic12, pic13, pic14, pic15, pic16, pic17, pic18, pic19, pic20;
        public static string ppic = "", ppic2 = "", ppic3 = "", ppic4 = "", ppic5 = "", ppic6 = "", ppic7 = "", ppic8 = "", ppic9 = "", ppic10 = "", ppic11 = "", ppic12 = "", ppic13 = "", ppic14 = "", ppic15 = "", ppic16 = "", ppic17 = "", ppic18 = "", ppic19 = "", ppic20 = "";
        public static bool bl1, bl2, bl3, bl4, bl5, bl6, bl7, bl8, bl9, bl10, bl11, bl12, bl13, bl14, bl15, bl16, bl17, bl18, bl19, bl20;

        private void button13_Click(object sender, EventArgs e)
        {
            Pict11.Image = null;
            ppic11 = "";
            pic11 = "";
            bl11 = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Pict12.Image = null;
            ppic12 = "";
            pic12 = "";
            bl12 = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Pict13.Image = null;
            ppic13 = "";
            pic13 = "";
            bl13 = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Pict14.Image = null;
            ppic14 = "";
            pic14 = "";
            bl14 = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Pict15.Image = null;
            ppic15 = "";
            pic15 = "";
            bl15 = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Pict16.Image = null;
            ppic16 = "";
            pic16 = "";
            bl16 = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
      
            Pict17.Image = null;
            ppic17 = "";
            pic17 = "";
            bl17 = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Pict18.Image = null;
            ppic18 = "";
            pic18 = "";
            bl18 = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Pict19.Image = null;
            ppic19 = "";
            pic19 = "";
            bl19 = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
         
            Pict20.Image = null;
            ppic20 = "";
            pic20 = "";
            bl20 = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
         
            Pict10.Image = null;
            ppic10 = "";
            pic10 = "";
            bl10 = true;
        }

       

        private void button9_Click(object sender, EventArgs e)
        {
            Pict9.Image = null;
            ppic9 = "";
            pic9 = "";
            bl9 = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pict8.Image = null;
            ppic8 = "";
            pic8 = "";
            bl8 = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pict7.Image = null;
            ppic7 = "";
            pic7 = "";
            bl7 = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pict6.Image = null;
            ppic6 = "";
            pic6 = "";
            bl6 = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            Pict5.Image = null;
            ppic5 = "";
            pic5 = "";
            bl5 = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pict4.Image = null;
            ppic4 = "";
            pic4 = "";
            bl4 = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pict3.Image = null;
            ppic3 = "";
            pic3 = "";
            bl3 = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Pict2.Image = null;
            ppic2 = "";
            pic2 = "";
            bl2 = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
          
            Pict1.Image = null;
            ppic = "";
            pic = "";
            bl1 = true;
        }

        private void УдалениКартинки(PictureBox picturebox,string ppic,string pic, bool bl)//Метод удаление картинки и очистка переменных
        {
         
                picturebox.Image = null;
                ppic = "";
                pic = "";
                bl = true;
           
            
        }

        private void Pict1_Click(object sender, EventArgs e)
        {
           
            File.Open(ppic,FileMode.Open,FileAccess.Read);
        }

        string LoadPic(PictureBox Pic)
        {
            var of = new OpenFileDialog();
            of.Title = "Выберите фото для отчёта";
            of.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG|*.BPM;*.JPG;*.GIF;*.PNG| All Files(*.*)|*.*)";
            of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   
                    Pic.Image = Image.FromFile(of.FileName);
                  

                }
                catch (Exception b)
                {

                    MessageBox.Show(b.ToString());
                }
            }
            of.Dispose();
     
            //GC.Collect();
            return of.FileName;
           
          

        }


        void недоступность(bool fl,TextBox tb, PictureBox pic)
        {
            tb.Enabled = false;
            if (pic.Image != null)
            {
                tb.Enabled = fl;
                tb.Select();
            }
        }


        #region Регион обработчика




        private void TB1_Leave(object sender, EventArgs e)
        {
            Массив[0] = TB1.Text;
        }

        private void TB2_Leave(object sender, EventArgs e)
        {
            Массив[1] = TB2.Text;
        }

        private void TB3_Leave(object sender, EventArgs e)
        {
            Массив[2] = TB3.Text;
        }

        private void TB4_Leave(object sender, EventArgs e)
        {
            Массив[3] = TB4.Text;
        }

        private void TB5_Leave(object sender, EventArgs e)
        {
            Массив[4] = TB5.Text;
        }

        private void TB6_Leave(object sender, EventArgs e)
        {
            Массив[5] = TB6.Text;
        }

        private void TB7_Leave(object sender, EventArgs e)
        {
            Массив[6] = TB7.Text;
        }  

        private void TB8_Leave(object sender, EventArgs e)
        {
            Массив[7] = TB8.Text;
        }

        private void TB9_Leave(object sender, EventArgs e)
        {
            Массив[8] = TB9.Text;
        }

        private void TB10_Leave(object sender, EventArgs e)
        {
            Массив[9] = TB10.Text;
        }

        private void TB11_Leave(object sender, EventArgs e)
        {
            Массив[10] = TB11.Text;
        }

        private void TB12_Leave(object sender, EventArgs e)
        {
            Массив[11] = TB12.Text;
        }

        private void TB13_Leave(object sender, EventArgs e)
        {
            Массив[12] = TB13.Text;
        }

        private void TB14_Leave(object sender, EventArgs e)
        {
            Массив[13] = TB14.Text;
        }

        private void TB15_Leave(object sender, EventArgs e)
        {
            Массив[14] = TB15.Text;
        }

        private void TB16_Leave(object sender, EventArgs e)
        {
            Массив[15] = TB16.Text;
        }

        private void TB17_Leave(object sender, EventArgs e)
        {
            Массив[16] = TB17.Text;
        }

        private void TB18_Leave(object sender, EventArgs e)
        {
            Массив[17] = TB18.Text;
        }

        private void TB19_Leave(object sender, EventArgs e)
        {
            Массив[18] = TB19.Text;
        }

        private void TB20_Leave(object sender, EventArgs e)
        {
            Массив[19] = TB20.Text;
        }

        private void Photos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Массив[0] = TB1.Text;
            Массив[1] = TB2.Text;
            Массив[2] = TB3.Text;
            Массив[3] = TB4.Text;
            Массив[4] = TB5.Text;
            Массив[5] = TB6.Text;
            Массив[6] = TB7.Text;
            Массив[7] = TB8.Text;
            Массив[8] = TB9.Text;
            Массив[9] = TB10.Text;
            Массив[10] = TB11.Text;
            Массив[11] = TB12.Text;
            Массив[12] = TB13.Text;
            Массив[13] = TB14.Text;
            Массив[14] = TB15.Text;
            Массив[15] = TB16.Text;
            Массив[16] = TB17.Text;
            Массив[17] = TB18.Text;
            Массив[18] = TB19.Text;
            Массив[19] = TB20.Text;
            ГлавнаяФорма.checkform = false;
            GC.Collect();

          
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ppic = LoadPic(Pict1);
            if (ppic != "") pic = "";
            недоступность(true, TB1, Pict1);
            Массив[0] = TB1.Text;
            bl1 = true;
        }


        private void LoadBut2_Click(object sender, EventArgs e)
        {
            ppic2 = LoadPic(Pict2);
            if (ppic2 != "") pic2 = "";
            недоступность(true, TB2, Pict2);
            Массив[1] = TB2.Text;
            bl2 = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ppic3 = LoadPic(Pict3);
            if (ppic3 != "") pic3 = "";
            недоступность(true, TB3, Pict3);
            Массив[2] = TB3.Text;
            bl3 = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ppic4 = LoadPic(Pict4);
            if (ppic4 != "") pic4 = "";
            недоступность(true, TB4, Pict4);
            Массив[3] = TB4.Text;
            bl4 = true;
        }

        private void LoadBut5_Click(object sender, EventArgs e)
        {
            ppic5 = LoadPic(Pict5);
            if (ppic5 != "") pic5 = "";
            недоступность(true, TB5, Pict5);
            Массив[4] = TB5.Text;
            bl5 = true;
        }

        private void LoadBut6_Click(object sender, EventArgs e)
        {
            ppic6 = LoadPic(Pict6);
            if (ppic6 != "") pic6 = "";
            недоступность(true, TB6, Pict6);
            Массив[5] = TB6.Text;
            bl6 = true;
        }

        private void LoadBut7_Click(object sender, EventArgs e)
        {
            ppic7 = LoadPic(Pict7);
            if (ppic7 != "") pic7 = "";
            недоступность(true, TB7, Pict7);
            Массив[6] = TB7.Text;
            bl7 = true;
        }
        
        private void LoadBut8_Click(object sender, EventArgs e)
        {
            ppic8 = LoadPic(Pict8);
            if (ppic8 != "") pic8 = "";
            недоступность(true, TB8, Pict8);
            Массив[7] = TB8.Text;
            bl8 = true;
        }

        private void LoadBut12_Click(object sender, EventArgs e)
        {
            ppic12 = LoadPic(Pict12);
            if (ppic12 != "") pic12 = "";
            недоступность(true, TB12, Pict12);
            Массив[11] = TB12.Text;
            bl12 = true;
        }

        private void LoadBut11_Click(object sender, EventArgs e)
        {
            ppic11 = LoadPic(Pict11);
            if (ppic11 != "") pic11 = "";
            недоступность(true, TB11, Pict11);
            Массив[10] = TB11.Text;
            bl11 = true;
        }

        private void LoadBut10_Click(object sender, EventArgs e)
        {
            ppic10 = LoadPic(Pict10);
            if (ppic10 != "") pic10 = "";
            недоступность(true, TB10, Pict10);
            Массив[10] = TB11.Text;
            bl10 = true;
        }

        private void LoadBut9_Click(object sender, EventArgs e)
        {
            ppic9 = LoadPic(Pict9);
            if (ppic9 != "") pic9 = "";
            недоступность(true, TB9, Pict9);
            Массив[8] = TB9.Text;
            bl9 = true;
        }

        private void LoadBut13_Click(object sender, EventArgs e)
        {
            ppic13 = LoadPic(Pict13);
            if (ppic13 != "") pic13 = "";
            недоступность(true, TB13, Pict13);
            Массив[12] = TB13.Text;
            bl13 = true;
        }

        private void LoadBut14_Click(object sender, EventArgs e)
        {
            ppic14 = LoadPic(Pict14);
            if (ppic14 != "") pic14 = "";
            недоступность(true, TB14, Pict14);
            Массив[13] = TB14.Text;
            bl14 = true;
        }

        private void LoadBut15_Click(object sender, EventArgs e)
        {
            ppic15 = LoadPic(Pict15);
            if (ppic15 != "") pic15 = "";
            недоступность(true, TB15, Pict15);
            Массив[14] = TB15.Text;
            bl15 = true;
        }

        private void LoadBut16_Click(object sender, EventArgs e)
        {
            ppic16 = LoadPic(Pict16);
            if (ppic16 != "") pic16 = "";
            недоступность(true, TB16, Pict16);
            Массив[15] = TB16.Text;
            bl16 = true;
        }

        private void LoadBut17_Click(object sender, EventArgs e)
        {
            ppic17 = LoadPic(Pict17);
            if (ppic17 != "") pic17 = "";
            недоступность(true, TB17, Pict17);
            Массив[16] = TB17.Text;
            bl17 = true;
        }

        private void LoadBut18_Click(object sender, EventArgs e)
        {
            ppic18 = LoadPic(Pict18);
            if (ppic18 != "") pic18 = "";
            недоступность(true, TB18, Pict18);
            Массив[17] = TB18.Text;
            bl18 = true;
        }

        private void LoadBut19_Click(object sender, EventArgs e)
        {
           ppic19 = LoadPic(Pict19);
            if (ppic19 != "") pic19 = "";
            недоступность(true, TB19, Pict19);
            Массив[18] = TB19.Text;
            bl19 = true;
        }

        private void LoadBut20_Click(object sender, EventArgs e)
        {
            ppic20 = LoadPic(Pict20);
            if (ppic20 != "") pic20 = "";
            недоступность(true, TB20, Pict20);
            Массив[19] = TB20.Text;
            bl20 = true;
        }

        #endregion

        private void button11_Click(object sender, EventArgs e) // Далее
        {
            if (PageNumberLB.Text == "1 из 5")
            {
                button12.Enabled = true;
                PageNumberLB.Text = "2 из 5";
                groupPage(GR2, GR1, GR3,GR4,GR5);
            }
            else if (PageNumberLB.Text == "2 из 5")
            {
                PageNumberLB.Text = "3 из 5";
                groupPage(GR3, GR2, GR1, GR4, GR5);
               
            }
            else if (PageNumberLB.Text == "3 из 5")
            {
                PageNumberLB.Text = "4 из 5";
                groupPage(GR4, GR3, GR2, GR1, GR5);
            
            }

            else if (PageNumberLB.Text == "4 из 5")
            {
                PageNumberLB.Text = "5 из 5";
                groupPage(GR5, GR3, GR2, GR1, GR4);
                button11.Enabled = false;
            }



        }

        private void button12_Click(object sender, EventArgs e) //Назад
        {
            if (PageNumberLB.Text == "5 из 5")
            {
                button11.Enabled = true;
                PageNumberLB.Text = "4 из 5";
                groupPage(GR4, GR1, GR2, GR3, GR5);
            }
            else if (PageNumberLB.Text == "4 из 5")
            {
               
                PageNumberLB.Text = "3 из 5";
                groupPage(GR3, GR1, GR2, GR4, GR5);
            }
            else if (PageNumberLB.Text == "3 из 5")
            {
               
                PageNumberLB.Text = "2 из 5";
                groupPage(GR2, GR1, GR3, GR4, GR5);
            }
            else if (PageNumberLB.Text == "2 из 5")
            {
                PageNumberLB.Text = "1 из 5";
                groupPage(GR1, GR2, GR3, GR4, GR5);
                button12.Enabled = false;
            }
        }

        public static string[] Массив = new string[50];
    
    }
}
