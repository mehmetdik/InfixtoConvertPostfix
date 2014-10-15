using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021HW1
{
    class infixToConvertPostfix
    {
        public string[] divide(string value)//Bu fonksiyonda girdiyi substring ile karakterlerine ayırıp oluşturduğumuz 
        {
            string[] array = new string[value.Length];//string türünde girdinin uzunluğunda bir dizi oluşturduk.
            for (int i = 0; i < value.Length; i++)
            {
                array[i] = value.Substring(i, 1);//girdiyi substrin ile ayırdık diziye atadık.
            }
            return array;//diziyi dönderdik.

        }


        public string ipConvert(string[] array2, Stack<string> stck)//infix ifadeyi postfix ifadeye ceviren fonksiyonu oluşturduk.
        {
            Console.WriteLine("Postfix:");
            string str = null;
            for (int i = 0; i < array2.Length; i++)
            {
                if (array2[i].Equals("*") || array2[i].Equals("/") || array2[i].Equals("+") || array2[i].Equals("-"))//dizinin elemanları *,/,+,- operatörlerinden farklı bir karekter ise içeri gir.
                {
                    str = str + " ";//str stringine str artı bir boşluk ekle.
                    str = comperation(array2[i], stck, str);//comperation fonksiyonunu çağırdık ve str'ye eşitledik.comperation'da operatör önceliklerini belirler.

                }
                else
                {
                    str = write(array2[i], str);//write methodunu çağırdık ve str'ye atadık.
                }
            }
            while (!stck.isEmpty())//stack boş olana kadar döner
            {
                str = str + " " + stck.pop();//str'ye str artı bir boşluk ve stack'de bulunan ilk elemanı poplıyarak çıkardık.
            }
            return str;
        }


        public string write(string array2, string str1)//sayıları str1 'e yazdırır yanyana
        {

            str1 = str1 + array2;
            return str1;
        }


        public string comperation(string array2, Stack<string> stck, string str)//operörleri sıralayıp ona göre staca atar.
        {

            if (stck.isEmpty())//stack boş ise içeri girer.
            {
                stck.push(array2);//array2 stringini stacke ekler.
            }
            else
            {
                string stackyedek = stck.pop(); //stackyedek olan string değişkenine stack'den çıkardığı elamana atadık.
                int gecici = operatorToPrecedence(array2);//çağırdığımız fonksiyonda operatörlerin değerlerini dönderiyor ve dönderilen değeri gecici değişkene atıyor.
                int gecici2 = operatorToPrecedence(stackyedek);//çağırdığımız fonksiyonda operatörlerin değerlerini dönderiyor ve dönderilen değeri gecici değişkene atıyor.
                if (gecici2 > gecici)//operatörlerin önceliğini belirler.
                {
                    str = str + stackyedek;
                    while (!stck.isEmpty())//döngü stack dolana kadar döngü devam edeck.
                    {
                        str = str + stck.pop();//str'ye str artı stackdeki çıkardığımız 'atar.
                    }
                    stck.push(array2);//array2'deki ifadeyi ekler.
                }
                else if (gecici2 < gecici)
                {
                    stck.push(stackyedek.ToString());
                    stck.push(array2);
                }
                else
                {
                    str = str + stackyedek;
                    stck.push(array2);
                }
            }
            return str;
        }


        public int operatorToPrecedence(string operatr)//Operatör önceliğini belirler.
        {
            if (operatr.Equals("+"))
            {
                return 0;
            }
            else if (operatr.Equals("-"))
            {
                return 0;
            }
            else if (operatr.Equals("*"))
            {
                return 1;
            }
            else if (operatr.Equals("/"))
            {
                return 1;
            }
            else
            {
                return 3;
            }

        }


        public double SonucBulma(string value, string str)//postfix ifade üzerinden sonucu bulur.
        {



            Stack<string> stk2 = new Stack<string>(value.Length);//stack oluşturduk.
            string YedekStr = null;
            double sayi1 = 0, sayi2 = 0;
            double Total = 0, Total2 = 0;
            for (int i = 0; i < str.Length; i++)
            {

                if (str.Substring(i, 1).Equals(" "))//str'deki girdiyi substring ile ayırdığımız karekter boşluk ise  içeri girer.
                {
                    continue;
                }
                else if (str.Substring(i, 1).Equals("*"))//str'deki girdiyi substring ile ayırdığımız karekter * ise  içeri girer.
                {
                    sayi1 = Convert.ToInt32(stk2.pop());//popladığı karekteri inte çevirir ve sayi1 değişkenine atar.
                    sayi2 = Convert.ToInt32(stk2.pop());//popladığı karekteri inte çevirir ve sayi2 değişkene atar.
                    Total = sayi1 * sayi2;
                    YedekStr = Convert.ToString(Total);//toplamı stringe çevirdi ve yedekstr'ye atadı.
                    stk2.push(YedekStr);//yedekstr'yi ekledi stack'e

                }
                else if (str.Substring(i, 1).Equals("/"))//str'deki girdiyi substring ile ayırdığımız karekter / ise  içeri girer.
                {
                    sayi1 = Convert.ToInt32(stk2.pop());
                    sayi2 = Convert.ToInt32(stk2.pop());
                    Total = (sayi2 / sayi1);
                    YedekStr = Convert.ToString(Total);
                    stk2.push(YedekStr);
                }
                else if (str.Substring(i, 1).Equals("+"))
                {
                    sayi1 = Convert.ToInt32(stk2.pop());
                    sayi2 = Convert.ToInt32(stk2.pop());
                    Total = sayi1 + sayi2;
                    YedekStr = Convert.ToString(Total);
                    stk2.push(YedekStr);
                }
                else if (str.Substring(i, 1).Equals("-"))
                {
                    sayi1 = Convert.ToInt32(stk2.pop());
                    sayi2 = Convert.ToInt32(stk2.pop());
                    Total = sayi2 - sayi1;
                    YedekStr = Convert.ToString(Total);
                    stk2.push(YedekStr);
                }
                else
                {
                    string sayi = null;
                    Boolean kontrol = true;
                    while (!(str.Substring((i), 1).Equals(" ")))//str boşlu değilse dön.
                    {
                        {
                            sayi += str.Substring(i, 1);
                            i++;
                        }
                        kontrol = false;
                    }
                    if (kontrol)
                    {
                        stk2.push(str.Substring(i, 1));
                    }
                    else
                    {
                        i--;
                        stk2.push(sayi);
                    }
                }
            }
            Total2 = Convert.ToDouble(stk2.pop());
            return Total2;

        }
    }
}
