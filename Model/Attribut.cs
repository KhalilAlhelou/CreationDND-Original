namespace Model
{
    public class Attribut
    {
        public string nom { get; private set; }
        public string description { get; private set; }

        public Attribut (AttributDTO attributDTO)
        {
            this.nom = attributDTO.NomAttribut;
            this.description = attributDTO.DescriptionAttribut;
        }
    }
}