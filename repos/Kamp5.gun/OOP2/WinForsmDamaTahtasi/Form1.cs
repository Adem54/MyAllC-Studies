using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForsmDamaTahtasi
{
    public partial class Form1 : Form
    {
        public Form1()//Constructor
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateButton();

        }

        private void GenerateButton()
        {
            //Button button = new Button();
            //IKI BOYUTLU DIZI..
            Button[,] buttons = new Button[8, 8];
            //Bu sekilde yapinca istedimiz butona da rahat bir sekilde erisebiliriz...Her satir da 8 kutu olmali
            //buttons.GetUpperBound(0) demeek 2 butonlu bir arrayda butonun 0. boyutu demektir ve 0. boyutun alabilecegi en buyuk deger 7 dir yani totalde
            //totald e 0 la birlikte 8 dir
            int top = 0;//Degiskenlerin burda tanimlanmasii cok onemli cunku tum methodlarin icinde ve nerde ihtiyacimiz olursa orda kullanabiliyoruz
            int left = 0;

            for (int i = 0; i < buttons.GetUpperBound(0); i++)//8 satir icin deger olusturduk
            {
                //Simdi de her bir satir da iken 8 er tane button olusturmam lazm
                for (int j = 0; j < buttons.GetUpperBound(1); j++)
                {
                    //[i,j]=>0,0 0.satirin ilk butonu, [0,1] 0. satirin ikinci butonu [0,2] 0.satirin 2.buton u seklinde gidecektir
                    //Her button bizim icin yeni bir buttondur ondan dolayi onu herseferinde new lememiz gerekiyor
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 50;
                    buttons[i, j].Height = 50;
                    buttons[i, j].Left = left;
                    left += 50;//Left boslugu 50 arttir her donmede
                    buttons[i, j].Top = top;
                    if ((i + j) % 2 == 0)
                    {
                        buttons[i, j].BackColor = Color.Black;
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.White;
                    }

                    this.Controls.Add(buttons[i, j]);
                }//Burasi her bir donmede bir satir tamamlanmali yani burasi 8 kez donuyor i=0 ken sonra i=1 olunca da 8 kez donuyor
                //Burasi ilk satiri bitirince hemen ardindan left i sifirlamaliyim ki yanyana koymaya devam etmesin ve ikinci satirda ku kutuyu tekrardan 
                //en sola yaslasin
                left = 0;
                top += 50;//Her satirda bir kutu asagi inmesi icin yaparizb bunu
            }

            // button.Width = 50;//Dikkat edelim Button bir class Width de class in bir ozelligi niye cunku parantez yok
            //parantez olsa idi bir methodu olurdu
            // button.Height = 50;
            // button.Text = "MyButton";
            //Formda bir buton olusmasini sagliyor
            // this.Controls.Add(button);
            //Biz simdi 64 tane kutu olusturmak icin bunlari for dongusu ile dondurursek o zaman her bir kutuya erisimi kaybederiz cunku her bir donmesinde
            //bir class newlyecek ve biz kutulara erisimimiz zorlasacak
            //for la dondurmek yerine biz Button class indan bir 64 elemanli dizi olustururuz oncelikle ve 8 e 8 olacak sekilde dizi olusturabiliriz
        }




        //Form acilinca calisan kod burasidir.O yuzden dama tahtasi yapmak icin kodlarimizi bu bloga yazacagiz ki
        //form acilinca burasi calisiyor cunku
        //Amacimiz her satirda 8 tane kare blok yapmak toplamda 8x8 64 tane kutu olacak 8 kenarli bir kare gibi dusunuyoruz
        //8x8 li buton olusturacagiz aslinda
        //Bu arada sonu cs ile biten hersey C# da class tir yani f
        //orm un kendisi bir class tir butonun kendisi bir class tir

    }
}
