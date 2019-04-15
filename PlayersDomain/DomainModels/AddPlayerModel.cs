namespace PlayersDomain.DomainModels
{
    public class AddPlayerModel
    {
        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public int Visina { get; set; }

        public int Tezina { get; set; }

        public int KlubId { get; set; }

        public int DrzavaId { get; set; }
    }
}
