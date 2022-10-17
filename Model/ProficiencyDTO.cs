namespace Model
{
    public class ProficiencyDTO
    {
        public int id;
        public string nom;

        public ProficiencyDTO(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }
    }
}