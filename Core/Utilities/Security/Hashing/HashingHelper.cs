using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //passwordHash olusturcaz.Ona verdigimiz bir passwoedun hashini saltını olusturcak
        //out=oraya gönderilen iki degerimiz bos bile olsa onu doldurup geri donduremye yarıyor.Burdaki out key wordunu dısarıya verilcek deger gibi dusunebiliriz
        //Kısacası biz password degeri vericez ve dısarıya su iki yapı cıkacak=>out byte[] passwordHash, out byte[] passwordSalt
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//ilgili algoritmanın olsuturdugu key'dir.Her kullanıcı için farklı bir key degeri olusur bunun için güvenlidir.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //password string bunu byte[] 'e cevirmemiz lazım bunun için=>(Encoding.UTF8.GetBytes yöntemi kullanacağız
            }
        }

        //Benim elimde bir sifre var sen bu kullanıcın göndediği passwordu yine aynı algoritmayı kullanarak hashlesseydin karsına bu mu cıkacak yani passwordHash bizim veritabanındaki hash'imiz olucak
        //kullanıcın gönderdiği ve veritabaındaki hash'i karsılastıracagız
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])//benim computed hash'im veritabanından gönderilen password hashe esit mi degil mi?
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
