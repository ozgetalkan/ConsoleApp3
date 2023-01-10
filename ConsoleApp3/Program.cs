using System.Collections;

namespace ConsoleApp3
{
    #region // Ornek 2
    public class Sirket
    {
        public int Id { get; set; }
        public string Unvani { get; set; }
        public List<Personel> PersonelListesi = new();
        public Personel NewPersonel()
        {
            Personel personel = new();
            personel.SirketId = this.Id;
            personel.Sirket = this;
            PersonelListesi.Add(personel);
            return personel;
        }
        public Personel NewPersonel(string adSoyad)
        {
            Personel p = NewPersonel();
            p.AdSoyad = adSoyad;
            return p;
        }
    }
    public class Personel
    {
        internal Personel() { }
        public Personel(Sirket s)
        {
            this.Sirket = s;
            this.SirketId = s.Id;
        }
        public int Id { get; set; }
        public int SirketId { get; set; }
        public Sirket Sirket { get; set; }
        public string SicilNo { get; set; }
        public string AdSoyad { get; set; }
        public string Bolum { get; set; }

    }
    class Test
    {
        List<Sirket> sirketler = new();
        void PrintPersonelInfo(Personel p)
        {
            Console.Write(p.SicilNo);
            Sirket s = sirketler.FirstOrDefault(x => x.Id == p.SirketId);
            Console.WriteLine(s.Unvani);
        }
    }
    #endregion
    #region // Ornek 1
    enum Field
    {
        Ad,
        Soyad,
        Yas,
        Sehir
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DataRow row = new();
            row.AddValue("Özge");
            row.AddValue("Alkan");
            row.AddValue(27);
            row.AddValue("İstanbul");

            DataTable dataTable = new();
            dataTable.Rows.Add(row);

            foreach (var rowItem in dataTable.Rows)
            {
                Console.WriteLine(rowItem[(int)Field.Sehir].ToString());
                foreach (var column in rowItem)
                {
                    Console.WriteLine(column.ToString());
                }
            }
        }
    }
    class DataTable
    {
        public List<DataRow> Rows = new();
    }
    class DataRow : IEnumerable, IEnumerator
    {
        private List<Object> internalData = new();
        public void AddValue(object value)
        {
            internalData.Add(value);
        }
        public override string ToString()
        {
            return String.Join(";", internalData);
        }
        public object this[int i]
        {
            get
            {
                return internalData[i];
            }
            set
            {
                internalData[i] = value;
            }
        }
        public int ColumnCount
        { get { return internalData.Count; } }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        int isaret = -1;
        public bool MoveNext()
        {
            if (isaret < this.internalData.Count - 1)
            {
                isaret++;
                return true;
            }
            else { return false; }
        }
        public void Reset()
        {
            isaret = -1;
        }
        public object Current => this.internalData[isaret];
    }
    #endregion
}