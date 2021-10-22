using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TredingDemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İslem1 çalıştı!");
        }
        //DEFAULT TRED ÇALIŞMA TARZI    
        //Tred default olarak çalışması şu şekildedir. Gelen bir işi işleme alınır ve o işlem bitene kadar gelen yeni istekler sıraya konur ve beklerler
        //neyi beklerle kendinden önce işleme girmiş olan o işin tamamen bitmesini bekler diğer istekler işlem de olan o iş tamamen bitmeden sırada bekleyen
        //işlemler işleme alınmaz
        //Şöyle düşünelim single tred i elimizde tek borumuz var işlemlerimiz tek borudan gidiyor ve ilk kullanıcı o borudan isteği gönderince diğerleri sıraya giriyor
        //ve ilk kullanıcının tüm işlemleri bitinceye kadar diğerleri sırada bekler ve ilk kullanıcı borudan çıktıktan sonra sırada bekleyen işlemler yine sıraya
        //göre işleme alınır
        //MULTITHRED ÇALIŞMA TARZI
        //Burda ise şöyle düşünelim her kullanıcı veya her istek için bir boru kullanıyor ve kimse sırada beklemiyor ve çok iyi bir performansla çalışıyor
        //ama bu belli bir seviyeddeki yoğunluğa kadar performans harika çalışır ama belli bir limitten sonrada performans düşüşe geçecektir yani burda
        //da herşey sorunsuz değil
        //Biz işlem sayısına göre her işlem içinm oluşuturulan thread lerin tamamına Threadpool-Threadhavuzu deniyor
        //Multitred te de işlem sayısının çokluğuna göre limitsiz bir boru oluşturmuyor tabi ki onun da bir limiti var mesela diyelim ki 8 tane boru oluşturdu ve
        //işlem sayımız ise 9 tane geldi 9 isteğin 8 ini boş olan 8 boruya gönderiyor kalan1 tane istek beklemeye alınıyor ve 8 borudaki işlemlerin ilk önce hangisi
        //biterse beklemeye alınan istek ilk işlemi biten boruda işlem biter bitmez işleme alınıyor
        //Biz illaki multitred kullanacağız diye birşey yok eğer bizim kullanıcımız az olacak ve az kullanılacaksa ayrıca işlemlerin sıra ile yapılması bizim
        //için önemli ise ona göre bir sistem kurmuşsak tabi ki single tred ile çalışmak mantıklıdır illaki multitred olacak diye düşünmeyelim
        //Şunu unutmayalım bir windows form uygulamasında single thread vardır, console da da aynı şekildedir singlethread olarak çalışırlar
        //ASENKRON TARZI
        //asenkron zaman kuralsız demektir
        //Asenkronda bir tane boruda çalışabilir birden fazla boruda ihtiyaca göre çalışabiliyor ancak asenkrondaki asıl olay şudur ki, bir istek işleme alındığı
        //zamnan o isteğin işlemleri diyelim kki borunun yarısına kadar geldi ve yeni bir istek daha var o istek de aynı boruda işleme alınıyor, işlemi devam eden
        //isteğin işlemleri sonlanmadan diğer bir istek de işleme alınıyor aynı anda bir boruda birden fazla istek alıp hepsini işleme alabiliyor demektir
        //Multitred de şunu unutmayalım hiçbirzaman iki işlem hiçbirzaman bir thread ortak kullanılamıyordur her işlem için yeni bir thread mantığı ve
        //belli bir limitten sonrada yine sıraya koyma ve ilkboşalan thread ile işlemlere devam ediliyordu
        //Multithread in oluşturacağı thread sayısı çekirdek sayısına göredir
        //Web uygulamalarında özellikle kullanılıyor yani multithread ile diyelim ki 8 tane thread oluşturuldu ise işlemlerin tamamı bu 8 thread e alındıktan sonra yeni
        //gelen istekler de asenkron programlama ile devam eden thread lere yapıştırılarak hiçbir istek beklememiş oluyor
        //Asenkron programlamada da birden fazla thread vardır ama illaki yeni bir thread olmasını beklemek gerekmiyor thread leri ortak kullanma söz konusudur

        private void btnProcess2_Click(object sender, EventArgs e)

        {
            MessageBox.Show("İslem2 çalıştı");
        }
    }
}
