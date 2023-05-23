using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //web apinin kullanacagı jwt ların olsuturmaya yarar
        //credentials elimizde olanlardır ad,soyad,email,password gibi(sisteme girmek için elimizde olan bigiler)
        //Burdaki credentiallarımız bizim ahatarımızıdır bu da securityKey'dir o da bize imzalama nesnesini dondurecektir.
        //anahatr olarak securityKey kullan, sifreleme olarak da güvenlik algoritmalarından HmacSha512 algosritmasını kullan
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
