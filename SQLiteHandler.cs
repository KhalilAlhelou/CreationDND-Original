using Microsoft.VisualBasic;
using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Xml.Linq;


    public class SQLiteHandler
    {
        public SQLiteHandler()
        {
        }
        public void initializeDB()
        {
            SQLiteConnection.CreateFile("dbCharacter.sqlite");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=dbCharacter.sqlite;Version=3;");
            m_dbConnection.Open();

        /**
        string sql = "drop table race";

        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        command.ExecuteNonQuery();
        **/
            string sql = "create table race (id int, name varchar(100), desc varchar(500))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        string desc = "Les Draconiques ressemblent beaucoup à des dragons se tenant debout sous une forme humanoïde, bien qu'ils n'aient ni ailes ni queue.";
            sql = "insert into race (id, name, desc) values (110, 'Draconique', '"+desc.Replace("'", "''") + "')";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "Audacieux et robustes, les nains sont connus pour être d'habiles guerriers, mineurs et travailleurs de la pierre et du métal.\r\n\r\nEn tant que nain des montagnes, vous êtes fort et robuste, habitué à une vie difficile en terrain accidenté. Vous êtes probablement de grande taille (pour un nain) et avez tendance à avoir une couleur plus claire. Les nains de bouclier du nord de Faerûn, ainsi que le clan Hylar au pouvoir et le noble clan Daewar de Dragonlance, sont des nains des montagnes.";
        sql = "insert into race (id, name, desc) values (120, 'Nain', '"+desc.Replace("'", "''") + "')";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "Audacieux et robustes, les nains sont connus pour être d'habiles guerriers, mineurs et travailleurs de la pierre et du métal.\r\n\r\nEn tant que nain des collines, vous avez des sens aiguisés, une profonde intuition et une remarquable résilience. Les nains d'or de Faerûn dans leur puissant royaume du sud sont des nains des collines, tout comme les Neidar exilés et les Klar avilis de Krynn dans le cadre de Dragonlance.\r\n\r\nTraduit avec www.DeepL.com/Translator (version gratuite)";
        sql = "insert into race (id, name, desc) values (121, 'Nain des collines', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "Audacieux et robustes, les nains sont connus pour être d'habiles guerriers, mineurs et travailleurs de la pierre et du métal.\r\n\r\nEn tant que nain des montagnes, vous êtes fort et robuste, habitué à une vie difficile en terrain accidenté. Vous êtes probablement de grande taille (pour un nain) et avez tendance à avoir une couleur plus claire. Les nains de bouclier du nord de Faerûn, ainsi que le clan Hylar au pouvoir et le noble clan Daewar de Dragonlance, sont des nains des montagnes.";
        sql = "insert into race (id, name, desc) values (122, 'Nain de montagne', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "Les eladrins sont un peuple magique d'une grâce surnaturelle, vivant dans le monde mais n'en faisant pas entièrement partie.\r\n\r\nEn tant que haut elfe, vous avez un esprit vif et vous maîtrisez au moins les bases de la magie. Dans de nombreux mondes de D&D, il existe deux types de hauts elfes. Le premier type (qui comprend les elfes gris et les elfes des vallées de Greyhawk, les Silvanesti de Dragonlance, et les elfes du soleil des Royaumes oubliés) est hautain et reclus, et se croit supérieur aux non-elfes et même aux autres elfes. L'autre type (y compris les hauts elfes de Greyhawk, les Qualinesti de Dragonlance et les elfes de la lune des royaumes oubliés) est plus commun et plus amical, et on le rencontre souvent parmi les humains et les autres races.\r\n\r\nLes elfes du soleil de Faerûn (également appelés elfes d'or ou elfes du soleil levant) ont une peau de bronze et des cheveux cuivrés, noirs ou blond doré. Leurs yeux sont dorés, argentés ou noirs. Les elfes de la lune (également appelés elfes d'argent ou elfes gris) sont beaucoup plus pâles, avec une peau d'albâtre parfois teintée de bleu. Leurs cheveux sont souvent blancs argentés, noirs ou bleus, mais il n'est pas rare qu'ils soient blonds, bruns ou roux. Leurs yeux sont bleus ou verts et mouchetés d'or.";
        sql = "insert into race (id, name, desc) values (130, 'Elfe', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        desc = "Les eladrins sont un peuple magique d'une grâce surnaturelle, vivant dans le monde mais n'en faisant pas entièrement partie.\r\n\r\nEn tant que haut elfe, vous avez un esprit vif et vous maîtrisez au moins les bases de la magie. Dans de nombreux mondes de D&D, il existe deux types de hauts elfes. Le premier type (qui comprend les elfes gris et les elfes des vallées de Greyhawk, les Silvanesti de Dragonlance, et les elfes du soleil des Royaumes oubliés) est hautain et reclus, et se croit supérieur aux non-elfes et même aux autres elfes. L'autre type (y compris les hauts elfes de Greyhawk, les Qualinesti de Dragonlance et les elfes de la lune des royaumes oubliés) est plus commun et plus amical, et on le rencontre souvent parmi les humains et les autres races.\r\n\r\nLes elfes du soleil de Faerûn (également appelés elfes d'or ou elfes du soleil levant) ont une peau de bronze et des cheveux cuivrés, noirs ou blond doré. Leurs yeux sont dorés, argentés ou noirs. Les elfes de la lune (également appelés elfes d'argent ou elfes gris) sont beaucoup plus pâles, avec une peau d'albâtre parfois teintée de bleu. Leurs cheveux sont souvent blancs argentés, noirs ou bleus, mais il n'est pas rare qu'ils soient blonds, bruns ou roux. Leurs yeux sont bleus ou verts et mouchetés d'or.";
        sql = "insert into race (id, name, desc) values (131, 'Haut elfe', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        desc = "Les eladrins sont un peuple magique d'une grâce surnaturelle, vivant dans le monde mais n'en faisant pas entièrement partie.\r\n\r\nEn tant qu'elfe des bois, vous avez des sens aiguisés et de l'intuition, et vos pieds légers vous portent rapidement et furtivement dans vos forêts natales. Cette catégorie comprend les elfes sauvages (grugach) de Greyhawk et les Kagonesti de Dragonlance, ainsi que les races appelées elfes des bois dans Greyhawk et les Royaumes oubliés. À Faerûn, les elfes des bois (également appelés elfes sauvages, elfes verts ou elfes des forêts) sont reclus et se méfient des non-elfes.\r\n\r\nLa peau des elfes des bois a tendance à être de couleur cuivrée, avec parfois des traces de vert. Leurs cheveux sont plutôt bruns et noirs, mais ils sont parfois blonds ou cuivrés. Leurs yeux sont verts, bruns ou noisette.";
        sql = "insert into race (id, name, desc) values (132, 'Elfe des bois', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        desc = "Les eladrins sont un peuple magique d'une grâce surnaturelle, vivant dans le monde mais n'en faisant pas entièrement partie.\r\n\r\nCette version de l'eladrin est apparue à l'origine dans le Guide du Maître du Donjon comme un exemple pour créer vos propres sous-races.\r\n\r\nCréatures magiques fortement liées à la nature, les eladrins vivent dans le royaume crépusculaire de la Féerie. Leurs villes traversent parfois le plan matériel, apparaissant brièvement dans des vallées montagneuses ou des clairières de forêts profondes avant de disparaître dans le monde féerique.";
        sql = "insert into race (id, name, desc) values (133, 'Elfe eladrin', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "Les demi-elfes combinent ce que certains appellent les meilleures qualités de leurs parents elfes et humains.";
        sql = "insert into race (id, name, desc) values (140, 'Demi-elfe', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "Certains demi-orques s'élèvent pour devenir de fiers leaders de communautés orques. D'autres s'aventurent dans le monde pour prouver leur valeur. Beaucoup d'entre eux deviennent des aventuriers, atteignant la grandeur grâce à leurs exploits.";
        sql = "insert into race (id, name, desc) values (150, 'Demi-orc', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "Les halflings de petite taille survivent dans un monde rempli de créatures plus grandes en évitant de se faire remarquer ou, à défaut, en évitant de se faire attaquer.\r\n\r\nEn tant que halfling aux pieds légers, vous pouvez facilement vous cacher, même en utilisant d'autres personnes comme couverture. Vous avez tendance à être affable et à bien vous entendre avec les autres. Dans les Royaumes Oubliés, les halflings aux pieds clairs se sont répandus le plus loin et sont donc la variété la plus commune.\r\n\r\nLes pieds-légers sont plus enclins à l'errance que les autres halflings, et s'installent souvent aux côtés d'autres races ou adoptent une vie nomade. Dans le monde de Greyhawk, on appelle ces halflings des pieds de poils ou des tallfellows.";
        sql = "insert into race (id, name, desc) values (160, 'Halfelin', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        desc = "Les halflings de petite taille survivent dans un monde rempli de créatures plus grandes en évitant de se faire remarquer ou, à défaut, en évitant de se faire attaquer.\r\n\r\nEn tant que halfling aux pieds légers, vous pouvez facilement vous cacher, même en utilisant d'autres personnes comme couverture. Vous avez tendance à être affable et à bien vous entendre avec les autres. Dans les Royaumes Oubliés, les halflings aux pieds clairs se sont répandus le plus loin et sont donc la variété la plus commune.\r\n\r\nLes pieds-légers sont plus enclins à l'errance que les autres halflings, et s'installent souvent aux côtés d'autres races ou adoptent une vie nomade. Dans le monde de Greyhawk, on appelle ces halflings des pieds de poils ou des tallfellows.";
        sql = "insert into race (id, name, desc) values (161, 'Halfling aux pieds légers', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
       
        desc = "Les halflings de petite taille survivent dans un monde rempli de créatures plus grandes en évitant de se faire remarquer ou, à défaut, en évitant de se faire attaquer.\r\n\r\nEn tant que halfling corpulent, vous êtes plus résistant que la moyenne et vous avez une certaine résistance au poison. Certains disent que les stouts ont du sang nain. Dans les Royaumes oubliés, on appelle ces halflings des cœurs forts, et ils sont plus courants dans le sud.";
        sql = "insert into race (id, name, desc) values (162, 'Halfelin Stout', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "Les humains sont les personnes les plus adaptables et les plus ambitieuses parmi les races communes. Quelle que soit leur motivation, les humains sont les innovateurs, les réalisateurs et les pionniers des mondes.";
        sql = "insert into race (id, name, desc) values (170, 'Humain', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        desc = "Les humains sont les personnes les plus adaptables et les plus ambitieuses parmi les races communes. Quelle que soit leur motivation, les humains sont les innovateurs, les réalisateurs et les pionniers des mondes.\r\n\r\nSi votre campagne utilise les règles d'exploits optionnels du Manuel du Joueur, votre Maître du Donjon peut autoriser ces variantes de traits, qui remplacent tous le trait Augmentation du score de capacité de l'humain.";
        sql = "insert into race (id, name, desc) values (171, 'Variente Humain', '"+desc.Replace("'", "''") + "')";
        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        desc = "L'énergie et l'enthousiasme d'un gnome pour la vie transparaissent dans chaque centimètre de son petit corps.\r\n\r\nEn tant que gnome des rochers, vous avez une inventivité et une résistance naturelles supérieures à celles des autres gnomes. La plupart des gnomes des mondes de D&D sont des gnomes de roche, y compris les gnomes bricoleurs de Dragonlance.";

        sql = "insert into race (id, name, desc) values (180, 'Gnome des roches', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        desc = "Être accueilli par des regards et des chuchotements, subir la violence et les insultes dans la rue, voir la méfiance et la peur dans chaque regard : tel est le lot du tiefling.";
        sql = "insert into race (id, name, desc) values (190, 'Tieffelin', '"+desc.Replace("'", "''") + "')";

        command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        m_dbConnection.Close();
        }

        public void showTable(string tableName)
        {

            using var con = new SQLiteConnection("Data Source=dbCharacter.sqlite;Version=3;");
            con.Open();

            string stm = "SELECT * FROM race";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Debug.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}");
            }
            

        }

        public raceCharacter getRace(string raceName)
        {

            using var con = new SQLiteConnection("Data Source=dbCharacter.sqlite;Version=3;");
            con.Open();

            string stm = "SELECT * FROM race WHERE name ='" + raceName+"'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            if (rdr.GetString(1).ToLower() == raceName.ToLower())
            {
               
                return new raceCharacter(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
            }
        }

        return null;
    }

    public raceCharacter getRace(int raceId)
    {
       
        using var con = new SQLiteConnection("Data Source=dbCharacter.sqlite;Version=3;");
        con.Open();

        string stm = "SELECT * FROM race WHERE id ='" + raceId+"'";

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            
         
            if (rdr.GetInt32(0) == raceId) { 

            return new raceCharacter(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
            }
        }

        return null;
    }
}
