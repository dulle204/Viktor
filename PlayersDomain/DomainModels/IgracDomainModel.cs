namespace PlayersDomain
{
    public  class IgracDomainModel
    {
        public int ID { get; set; }

        public string  Ime { get; set; }

        public string Prezime { get; set; }

        public string Visina { get; set; }

        public int Tezina { get; set; }

        public string Drzava { get; set; }

        public string Klub { get; set; }

        public string DrzavaKLuba { get; set; }

        public int KlubId { get; set; }

        public int DrzavaId { get; set; }
    }
}
