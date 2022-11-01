namespace Model
{
    public class CompetenceDTO
    {
        public int id;
        public string nom;

        public CompetenceDTO(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public override bool Equals(object? obj)
        {
            return obj is CompetenceDTO dTO &&
                   id == dTO.id &&
                   nom == dTO.nom;
        }
    }
}