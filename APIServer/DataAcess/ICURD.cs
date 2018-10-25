using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
namespace DataAcess
{
    public interface ICURD
    {
        bool Create();
        bool Read();
        bool Update();
        bool Delete();
    }
}
