using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapDemo1
{//Form uygulamasını açtığımızda uzantısı cs dir yani Form1.cs dir yani bir class tır, yani form uygulaması bir nesnedir
    //Amacımız 8 e 8 lik bir dama tahtası yapmak, yani uygulama açıldığında 8 e 8 lik bir dama tahtası yapmak
    //Biz uygulama açıldığında bu 8 e 8 lik dama tahtasının gelmesini istiyoruz, yani total de bize 64 tane buton gibi gerekiyor
    //Biz toolbox dan bir buton koyduğumuz zaman form a o buton bir classtır üzerine 2 kez tıklarsak onun kodlarına gidince bunu daha iyi görebiliriz
    public partial class Form1 : Form//Form class ı inheritance alınmış
    {
        public Form1()//Constructor çalışıyor ve içerisinde bir method çalışıyor yani new lediğmizde ilk olarak constructor çalışacak
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Biz bir butonu bu şekilde olşturup onun bazı özelliklerini değiştirebiliriz
            //Peki biz 64 tane bu şekilde buton ihtiyacımızı bu kodları 64 kez yazarak mı yapacağız
            // Ya da bu kodları tutup bir for döngüsü ile 64 kez döndürerek mi yapacağız bu şekiide döndürürsek butonlara erişimi
            // kaybederiz ve istediğimiz butona istediğimiz gibi erişemeyiz.Onun yerine daha profesyonel çalışmalıyız
            Button button = new Button();
            //Ya şöyle 64 elemanlı bir nesne oluşturmam lazım
            //Button[] buttons=new Button[64];
            //Ya da 8 e 8 lik button arrayi=> Button[,] buttons=new Button[8,8]=>Bu yöntemle yaptığımız zaman daha sonra rahatlıkla kontrol edebileceğiz
            button.Width = 50;
            button.Height = 50;
            button.Text = "MyButton";
            this.Controls.Add(button);//this bu class ın kendisidir yani form uygulamasıdır ki oraya buttonu ekle demiş oluyoruz aslında
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
//Verdiğmiz herhangi bir ismin daha önceden kullanıulmış class olduğunu anlamak için biz herhangi bir isim yazdığmızda zaten uyarı
//gelecektir hem simge olarak class oludğnu anlarız hemde bir açıklama gelecektir ordan da anlayabiliriz

//Algoritma mantığını unutmayalım bu çok çok önemli!
//siyah beyaz dama tahtası yapımı bunu yapalım bu önemli!!!!?????
//Bu dama tahtasını yapmadan önce algoritması üzerinde düşün ve madde madde yaz algoritmayı çünkü algoritma çok hayati dir