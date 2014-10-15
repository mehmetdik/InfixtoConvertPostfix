using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021HW1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Please enter to infix:");
            string value = Console.ReadLine();//Kullanıcıdan aldığımız girdiyi value değişkenine atadık.

            Stack<string> stk = new Stack<string>(value.Length);//Girilen girdi büyüklüğün de bir stack(string) oluşturduk.

            infixToConvertPostfix obj = new infixToConvertPostfix();//obje oluşturduk.
            string[] array2 = obj.divide(value);//Bir string dizisi oluşturduk ve diziye onjesini oluşturduğumuz sınıftan dönen arrayi atadık.Arryin için de giridnin karekterlere ayrılmış hali var. 

            string devam = obj.ipConvert(array2, stk);//Bir strin değişkeni oluşturduk değişkene objesini oluşturduğumuz 
            Console.WriteLine(devam);


            Console.WriteLine("Total:" + obj.SonucBulma(value, devam));//Objesini oluşturduğumuz clasda bulununan sonucbulma fonksiyonun dönderdiği sonucu yazdırıyoruz.
        }


    }
}
