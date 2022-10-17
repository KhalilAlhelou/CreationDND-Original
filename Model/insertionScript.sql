BEGIN TRANSACTION;
DROP TABLE IF EXISTS "attribute";
CREATE TABLE IF NOT EXISTS "attribute" (
	"idAttr"	INTEGER,
	"nameAttr"	TEXT,
	"descAttr"	TEXT,
	PRIMARY KEY("idAttr")
);
DROP TABLE IF EXISTS "race";
CREATE TABLE IF NOT EXISTS "race" (
	"idR"	INTEGER,
	"nameR"	TEXT,
	"descR"	TEXT,
	"bForceR"	INTEGER,
	"bDexR"	INTEGER,
	"bConstR"	INTEGER,
	"bIntR"	INTEGER,
	"bSageR"	INTEGER,
	"bCharR"	INTEGER,
	PRIMARY KEY("idR")
);
DROP TABLE IF EXISTS "class";
CREATE TABLE IF NOT EXISTS "class" (
	"idC"	INTEGER,
	"nameC"	TEXT,
	"descC"	BLOB,
	"hitPointC"	INTEGER,
	"isSpellcaster"	BOOLEAN,
	"bProfficiency"	INTEGER,
	"listAttrs"	BLOB,
	"bProfficiencyList"	TEXT,
	PRIMARY KEY("idC")
);
DROP TABLE IF EXISTS "proficiency";
CREATE TABLE IF NOT EXISTS "proficiency" (
	"pID"	INTEGER,
	"pName"	INTEGER,
	PRIMARY KEY("pID")
);
INSERT INTO "attribute" ("idAttr","nameAttr","descAttr") VALUES (201,'Rage','Au combat, vous vous battez avec une férocité primitive. À votre tour, vous pouvez entrer en rage comme une action bonus.
Lorsque vous êtes en rage, vous bénéficiez des avantages suivants si vous ne portez pas d''armure lourde :
Vous avez l''avantage sur les tests de Force et les jets de sauvegarde de Force.
Lorsque vous effectuez une attaque à l''arme de mêlée en utilisant la Force, vous bénéficiez d''un bonus au jet de dégâts qui augmente à mesure que vous gagnez des niveaux en tant que barbare, comme indiqué dans la colonne Dégâts de rage de la table Barbare.
Vous avez une résistance aux dégâts de matraquage, de perçage et d''entaille.
Si vous êtes capable de lancer des sorts, vous ne pouvez pas les lancer ou vous concentrer sur eux pendant votre rage.
Votre rage dure 1 minute. Elle se termine prématurément si vous êtes assommé ou si votre tour se termine et que vous n''avez pas attaqué une créature hostile depuis votre dernier tour ou subi de dégâts depuis. Vous pouvez également mettre fin à votre rage à votre tour en tant qu''action bonus.
Une fois que vous vous êtes mis en rage le nombre de fois indiqué pour votre niveau de barbare dans la colonne Rages de la table des barbares, vous devez terminer un long repos avant de pouvoir vous remettre en rage.'),
 (202,'Défense sans armure','Lorsque vous ne portez pas d''armure, votre classe d''armure est égale à 10 + votre modificateur de Dextérité + votre modificateur de Constitution. Vous pouvez utiliser un bouclier et bénéficier de cet avantage.'),
 (203,'Spellcasting','Vous avez appris à démêler et à remodeler le tissu de la réalité en harmonie avec vos souhaits et votre musique. Vos sorts font partie de votre vaste répertoire, une magie que vous pouvez adapter à différentes situations. Consultez les Règles des sorts pour connaître les règles générales du lancement de sorts et la Liste des sorts pour connaître la liste des sorts.'),
 (204,'Inspiration bardique','Vous pouvez inspirer les autres par des paroles ou de la musique émouvantes. Pour ce faire, vous utilisez une action bonus à votre tour pour choisir une créature autre que vous-même dans un rayon de 60 pieds de vous et qui peut vous entendre. Cette créature gagne un dé d''inspiration bardique, un d6.'),
 (205,'Domaine Divin','Choisissez un domaine lié à votre divinité : connaissance, vie, lumière, nature, tempête, ruse ou guerre. Le domaine Vie est détaillé à la fin de la description de la classe et fournit des exemples de dieux qui lui sont associés. Votre choix vous confère des sorts de domaine et d''autres caractéristiques lorsque vous le choisissez au 1er niveau. Il vous accorde également des moyens supplémentaires d''utiliser Canalisation de la divinité lorsque vous gagnez cette caractéristique au 2e niveau, et des avantages supplémentaires aux 6e, 8e et 17e niveaux.'),
 (206,'Druidique','Vous connaissez le druidique, le langage secret des druides. Vous pouvez parler cette langue et l''utiliser pour laisser des messages cachés. Vous et les autres personnes qui connaissent cette langue repèrent automatiquement un tel message. Les autres repèrent la présence du message en réussissant un test de Sagesse (Perception) DC 15, mais ne peuvent pas le déchiffrer sans magie.'),
 (207,'Style de combat','Vous adoptez un style de combat particulier comme spécialité. Choisissez l''une des options suivantes. Vous ne pouvez pas prendre une option de style de combat plus d''une fois, même si vous pouvez choisir à nouveau plus tard.'),
 (208,'Second Vent','Vous disposez d''une réserve d''endurance limitée dans laquelle vous pouvez puiser pour vous protéger des blessures. À votre tour, vous pouvez utiliser une action bonus pour regagner un nombre de points de vie égal à 1d10 + votre niveau de combattant. Une fois que vous avez utilisé cette caractéristique, vous devez terminer un repos court ou long avant de pouvoir l''utiliser à nouveau.'),
 (209,'Arts martiaux','Au 1er niveau, votre pratique des arts martiaux vous confère la maîtrise des styles de combat utilisant les frappes à mains nues et les armes de moine, c''est-à-dire les épées courtes et toute arme de mêlée simple qui n''a pas la propriété à deux mains ou lourde.
Vous gagnez les avantages suivants lorsque vous êtes désarmé ou que vous maniez uniquement des armes de moine et que vous ne portez pas d''armure ou ne maniez pas de bouclier :
Vous pouvez utiliser la Dextérité au lieu de la Force pour les jets d''attaque et de dégâts de vos frappes à mains nues et de vos armes de moine.
Vous pouvez lancer un d4 à la place des dégâts normaux de votre frappe à mains nues ou de votre arme de moine. Ce dé change à mesure que vous gagnez des niveaux de moine, comme indiqué dans la colonne Arts martiaux de la table des moines.
Lorsque vous utilisez l''action Attaque avec une frappe à mains nues ou une arme de moine à votre tour, vous pouvez effectuer une frappe à mains nues comme action bonus. Par exemple, si vous utilisez l''action Attaque et que vous attaquez avec une quarterstaff, vous pouvez également effectuer une frappe à mains nues en tant qu''action bonus, en supposant que vous n''ayez pas déjà effectué une action bonus ce tour-ci.
Certains monastères utilisent des formes spécialisées des armes de moine. Par exemple, vous pouvez utiliser une massue constituée de deux morceaux de bois reliés par une courte chaîne (appelée nunchaku) ou une faucille à la lame plus courte et plus droite (appelée kama). Quel que soit le nom que vous donnez à une arme de moine, vous pouvez utiliser les statistiques de jeu fournies pour cette arme dans la section Armes.'),
 (210,'Le sens divin','La présence d''un mal puissant est perceptible à vos sens comme une odeur nocive, et un bien puissant résonne à vos oreilles comme une musique céleste. Comme une action, vous pouvez ouvrir votre conscience pour détecter de telles forces. Jusqu''à la fin de votre prochain tour, vous connaissez l''emplacement de tout céleste, démon ou mort-vivant se trouvant à moins de 60 pieds de vous et qui n''est pas totalement couvert. Vous connaissez le type (céleste, démon ou mort-vivant) de tout être dont vous sentez la présence, mais pas son identité (le vampire Comte Strahd von Zarovich, par exemple). Dans le même rayon, vous détectez également la présence de tout lieu ou objet qui a été consacré ou profané, comme avec le sort hallow.
Vous pouvez utiliser cette caractéristique un nombre de fois égal à 1 + votre modificateur de Charisme. Lorsque vous terminez un long repos, vous récupérez toutes les utilisations dépensées.'),
 (211,'Imposition des mains','Votre toucher béni peut guérir les blessures. Vous disposez d''une réserve de pouvoir de guérison qui se reconstitue lorsque vous prenez un long repos. Avec cette réserve, vous pouvez restaurer un nombre total de points de vie égal à votre niveau de paladin × 5.'),
 (212,'Ennemi favori','À partir du 1er niveau, vous avez une expérience significative dans l''étude, la traque, la chasse et même la conversation avec un certain type d''ennemi.'),
 (213,'Explorateur naturel','Vous êtes particulièrement familier avec un type d''environnement naturel et êtes capable de voyager et de survivre dans ces régions. Choisissez un type de terrain favori : arctique, côte, désert, forêt, prairie, montagne, marécage ou souterrain. Lorsque vous effectuez un test d''Intelligence ou de Sagesse lié à votre terrain favori, votre bonus de compétence est doublé si vous utilisez une compétence que vous maîtrisez.'),
 (214,'Expertise','Au 1er niveau, choisissez deux de vos compétences, ou une de vos compétences et votre compétence en outils de voleur. Votre bonus de compétence est doublé pour tout test d''aptitude que vous effectuez et qui utilise l''une ou l''autre des compétences choisies.'),
 (215,'Attaque sournoise','À partir du 1er niveau, vous savez comment frapper subtilement et exploiter la distraction d''un ennemi. Une fois par tour, vous pouvez infliger 1d6 dégâts supplémentaires à une créature que vous touchez avec une attaque si vous avez l''avantage sur le jet d''attaque. L''attaque doit utiliser une arme fine ou à distance.'),
 (216,'Chant des voleurs','Pendant votre formation de voleur, vous avez appris le cant des voleurs, un mélange secret de dialecte, de jargon et de code qui vous permet de cacher des messages dans une conversation apparemment normale. Seule une autre créature connaissant le cant des voleurs peut comprendre de tels messages. Il faut quatre fois plus de temps pour transmettre un tel message que pour exprimer la même idée en clair.'),
 (217,'Origine sorcière','Choisissez une origine sorcière, qui décrit la source de votre pouvoir magique inné : Lignée de sang draconique, détaillée à la fin de la description de la classe, ou une autre source.'),
 (218,'Patron d''un autre monde','Au 1er niveau, vous avez conclu un marché avec un être d''un autre monde de votre choix : le Fiend, qui est détaillé à la fin de la description de classe, ou un autre. Votre choix vous accorde des caractéristiques au 1er niveau, puis au 6ème, 10ème et 14ème niveau.'),
 (219,'Pacte Magique','1er niveau
 Vos recherches arcaniques et la magie que vous a conférée votre protecteur vous ont permis d''acquérir une certaine facilité avec les sorts. Voir les Règles des sorts pour les règles générales du lancement de sorts et la Liste des sorts pour la liste des sorts du sorcier.
Cantrips
Vous connaissez deux cantrips de votre choix dans la liste des sorts de sorcier. Vous apprenez des cantrips supplémentaires de votre choix à des niveaux supérieurs, comme indiqué dans la colonne Cantrips Known de la table Warlock.
Emplacements pour les sorts
La table des sorciers indique le nombre d''emplacements de sorts dont vous disposez pour lancer vos sorts de sorcier du 1er au 5e niveau. La table indique également le niveau de ces emplacements ; tous vos emplacements de sorts sont de même niveau. Pour lancer un de vos sorts de sorcier de 1er niveau ou plus, vous devez dépenser un emplacement de sort. Vous récupérez tous les emplacements de sorts de Pacte Magique dépensés lorsque vous terminez un repos court ou long.
Par exemple, lorsque vous êtes au 5e niveau, vous avez deux emplacements pour sorts de 3e niveau. Pour lancer le sort de 1er niveau Éclair de sorcière, vous devez dépenser un de ces emplacements, et vous le lancez comme un sort de 3ème niveau.
Sorts connus de 1er niveau et plus
Au 1er niveau, vous connaissez deux sorts de 1er niveau de votre choix dans la liste des sorts de sorcier.
La colonne Sorts connus de la table des sorciers indique quand vous apprenez d''autres sorts de sorcier de votre choix, de 1er niveau et plus. Le sort que vous choisissez doit être d''un niveau qui n''est pas supérieur à celui indiqué dans la colonne Slot Level de la table pour votre niveau. Lorsque vous atteignez le 6e niveau, par exemple, vous apprenez un nouveau sort de sorcier, qui peut être de 1er, 2e ou 3e niveau.
De plus, lorsque vous gagnez un niveau dans cette classe, vous pouvez choisir un des sorts de sorcier que vous connaissez et le remplacer par un autre sort de la liste des sorts de sorcier, qui doit également être d''un niveau pour lequel vous avez des emplacements de sorts.
Capacité de lanceur de sorts
Le charisme est votre capacité de lanceur de sorts pour vos sorts de sorcier. Vous utilisez donc votre charisme chaque fois qu''un sort fait référence à votre capacité de lanceur de sorts. De plus, vous utilisez votre modificateur de Charisme pour déterminer le jet de sauvegarde d''un sort de sorcier que vous lancez et pour effectuer un jet d''attaque avec un tel sort.
Valeur de sauvegarde des sorts = 8 + votre bonus de compétence + votre modificateur de Charisme.
Modificateur d''attaque des sorts = votre bonus de compétence + votre modificateur de Charisme.
Focalisation des sorts
Vous pouvez utiliser un foyer arcanique (voir la section Équipement d''aventurier) comme foyer de lancement de sorts pour vos sorts de sorcier.'),
 (220,'Récupération des arcanes ','1er niveau
 Vous avez appris à récupérer une partie de votre énergie magique en étudiant votre livre de sorts. Une fois par jour, lorsque vous terminez un court repos, vous pouvez choisir des emplacements de sorts dépensés pour récupérer. Les emplacements de sorts peuvent avoir un niveau combiné égal ou inférieur à la moitié de votre niveau de magicien (arrondi au supérieur), et aucun des emplacements ne peut être de 6e niveau ou plus.
 Par exemple, si vous êtes un sorcier de 4e niveau, vous pouvez récupérer jusqu''à deux niveaux d''emplacements de sorts. Vous pouvez récupérer soit un emplacement de sort de 2ème niveau, soit deux emplacements de sort de 1er niveau.');
INSERT INTO "race" ("idR","nameR","descR","bForceR","bDexR","bConstR","bIntR","bSageR","bCharR") VALUES (110,'Sangdragon','Les Draconiques ressemblent beaucoup à des dragons se tenant debout sous une forme humanoïde, bien qu''ils n''aient ni ailes ni queue.',2,0,0,0,0,1),
 (120,'Nain de colline','Audacieux et robustes, les nains sont connus pour être d''habiles guerriers, mineurs et travailleurs de la pierre et du métal. En tant que nain des collines, vous avez des sens aiguisés, une profonde intuition et une remarquable résilience. Les nains d''or de Faerûn dans leur puissant royaume du sud sont des nains des collines, tout comme les Neidar exilés et les Klar avilis de Krynn dans le cadre de Dragonlance.',0,0,2,0,1,0),
 (121,'Nain de montagne','Audacieux et robustes, les nains sont connus pour être d''habiles guerriers, mineurs et travailleurs de la pierre et du métal. En tant que nain des montagnes, vous êtes fort et robuste, habitué à une vie difficile en terrain accidenté. Vous êtes probablement de grande taille (pour un nain) et avez tendance à avoir une couleur plus claire. Les nains de bouclier du nord de Faerûn, ainsi que le clan Hylar au pouvoir et le noble clan Daewar de Dragonlance, sont des nains des montagnes.',2,0,2,0,0,0),
 (130,'Haut elfe','Les eladrins sont un peuple magique d''une grâce surnaturelle, vivant dans le monde mais n''en faisant pas entièrement partie. En tant que haut elfe, vous avez un esprit vif et vous maîtrisez au moins les bases de la magie. Dans de nombreux mondes de D&D, il existe deux types de hauts elfes. Le premier type (qui comprend les elfes gris et les elfes des vallées de Greyhawk, les Silvanesti de Dragonlance, et les elfes du soleil des Royaumes oubliés) est hautain et reclus, et se croit supérieur aux non-elfes et même aux autres elfes. L''autre type (y compris les hauts elfes de Greyhawk, les Qualinesti de Dragonlance et les elfes de la lune des royaumes oubliés) est plus commun et plus amical, et on le rencontre souvent parmi les humains et les autres races. Les elfes du soleil de Faerûn (également appelés elfes d''or ou elfes du soleil levant) ont une peau de bronze et des cheveux cuivrés, noirs ou blond doré. Leurs yeux sont dorés, argentés ou noirs. Les elfes de la lune (également appelés elfes d''argent ou elfes gris) sont beaucoup plus pâles, avec une peau d''albâtre parfois teintée de bleu. Leurs cheveux sont souvent blancs argentés, noirs ou bleus, mais il n''est pas rare qu''ils soient blonds, bruns ou roux. Leurs yeux sont bleus ou verts et mouchetés d''or.',0,2,0,1,0,0),
 (131,'Elfe sylvestre','Les eladrins sont un peuple magique d''une grâce surnaturelle, vivant dans le monde mais n''en faisant pas entièrement partie. En tant qu''elfe des bois, vous avez des sens aiguisés et de l''intuition, et vos pieds légers vous portent rapidement et furtivement dans vos forêts natales. Cette catégorie comprend les elfes sauvages (grugach) de Greyhawk et les Kagonesti de Dragonlance, ainsi que les races appelées elfes des bois dans Greyhawk et les Royaumes oubliés. À Faerûn, les elfes des bois (également appelés elfes sauvages, elfes verts ou elfes des forêts) sont reclus et se méfient des non-elfes. La peau des elfes des bois a tendance à être de couleur cuivrée, avec parfois des traces de vert. Leurs cheveux sont plutôt bruns et noirs, mais ils sont parfois blonds ou cuivrés. Leurs yeux sont verts, bruns ou noisette.',0,2,0,0,1,0),
 (132,'Elfe noir','Les eladrins sont un peuple magique d''une grâce surnaturelle, vivant dans le monde mais n''en faisant pas entièrement partie. Cette version de l''eladrin est apparue à l''origine dans le Guide du Maître du Donjon comme un exemple pour créer vos propres sous-races. Créatures magiques fortement liées à la nature, les eladrins vivent dans le royaume crépusculaire de la Féerie. Leurs villes traversent parfois le plan matériel, apparaissant brièvement dans des vallées montagneuses ou des clairières de forêts profondes avant de disparaître dans le monde féerique.',0,2,0,0,0,1),
 (140,'Demi-elfe','Les demi-elfes combinent ce que certains appellent les meilleures qualités de leurs parents elfes et humains.',0,0,0,0,0,2),
 (150,'Demi-orc','Certains demi-orques s''élèvent pour devenir de fiers leaders de communautés orques. D''autres s''aventurent dans le monde pour prouver leur valeur. Beaucoup d''entre eux deviennent des aventuriers, atteignant la grandeur grâce à leurs exploits.',2,0,1,0,0,0),
 (160,'Halfelin aux pieds légers','Les halflings de petite taille survivent dans un monde rempli de créatures plus grandes en évitant de se faire remarquer ou, à défaut, en évitant de se faire attaquer. En tant que halfling aux pieds légers, vous pouvez facilement vous cacher, même en utilisant d''autres personnes comme couverture. Vous avez tendance à être affable et à bien vous entendre avec les autres. Dans les Royaumes Oubliés, les halflings aux pieds clairs se sont répandus le plus loin et sont donc la variété la plus commune. Les pieds-légers sont plus enclins à l''errance que les autres halflings, et s''installent souvent aux côtés d''autres races ou adoptent une vie nomade. Dans le monde de Greyhawk, on appelle ces halflings des pieds de poils ou des tallfellows.',0,2,0,0,0,1),
 (161,'Halfelin Robuste','Les halflings de petite taille survivent dans un monde rempli de créatures plus grandes en évitant de se faire remarquer ou, à défaut, en évitant de se faire attaquer. En tant que halfling corpulent, vous êtes plus résistant que la moyenne et vous avez une certaine résistance au poison. Certains disent que les stouts ont du sang nain. Dans les Royaumes oubliés, on appelle ces halflings des cœurs forts, et ils sont plus courants dans le sud.',0,2,1,0,0,0),
 (170,'Humain','Les humains sont les personnes les plus adaptables et les plus ambitieuses parmi les races communes. Quelle que soit leur motivation, les humains sont les innovateurs, les réalisateurs et les pionniers des mondes.',1,1,1,1,1,1),
 (180,'Gnome des roches','L''énergie et l''enthousiasme d''un gnome pour la vie transparaissent dans chaque centimètre de son petit corps. En tant que gnome des rochers, vous avez une inventivité et une résistance naturelles supérieures à celles des autres gnomes. La plupart des gnomes des mondes de D&D sont des gnomes de roche, y compris les gnomes bricoleurs de Dragonlance.',0,0,1,2,0,0),
 (181,'Gnome de foret','L''énergie et l''enthousiasme d''un gnome pour la vie transparaissent dans chaque centimètre de son petit corps. En tant que gnome des rochers, vous avez une inventivité et une résistance naturelles supérieures à celles des autres gnomes. La plupart des gnomes des mondes de D&D sont des gnomes de roche, y compris les gnomes bricoleurs de Dragonlance.',0,1,0,2,0,0),
 (190,'Tieffelin','Être accueilli par des regards et des chuchotements, subir la violence et les insultes dans la rue, voir la méfiance et la peur dans chaque regard : tel est le lot du tiefling.',0,0,0,1,0,2);
INSERT INTO "class" ("idC","nameC","descC","hitPointC","isSpellcaster","bProfficiency","listAttrs","bProfficiencyList") VALUES (301,'Barbare','Un guerrier féroce d''origine primitive qui peut entrer dans une rage de combat.',12,0,2,'201;202','2:405;403;408;411;412;418'),
 (302,'Barde','Un magicien inspirant dont le pouvoir fait écho à la musique de la création',8,1,2,'203;204','3:0'),
 (303,'Clerc','Un champion sacerdotal qui manie la magie divine au service d''une puissance supérieure.',8,1,2,'203;205','2:407;410;414;415;413'),
 (304,'Druide','Un prêtre de l''Ancienne Foi, maniant les pouvoirs de la nature et adoptant des formes animales.',8,1,2,'203;206','2:402;405;413;410;411;412;415;418'),
 (305,'Guerrier','Un maître du combat martial, habile avec une variété d''armes et d''armures.',10,0,2,'207;208','2:401;405;403;407;413;412;418;408'),
 (306,'Moine','Un maître des arts martiaux, qui exploite la puissance du corps dans la poursuite de la perfection physique et spirituelle.',8,0,2,'202;209','2:401;403;407;413;415'),
 (307,'Paladin','Un guerrier saint lié à un serment sacré',10,0,2,'210;211','2:403;413;408;410;414;415'),
 (308,'Ranger','Un guerrier qui combat les menaces aux frontières de la civilisation.',10,0,2,'212;213','3:405;403;413;409;411;412;418'),
 (309,'Rogue','Un scélérat qui utilise la discrétion et la ruse pour surmonter les obstacles et les ennemis.',8,0,2,'214;215;216','4:401;403;413;408;409;412;414;'),
 (310,'Sorcier','Un lanceur de sorts qui utilise la magie inhérente d''un don ou d''une lignée.',6,1,2,'203;217','2:402;417;413;408;414;415'),
 (311,'Warlock','Manipulateur de magie issue d''un marché avec une entité extraplanaire.',8,0,2,'218;219','2:402;417;407;408;409;411;415'),
 (312,'Magicien','Un utilisateur de magie érudit capable de manipuler les structures de la réalité.',6,1,2,'203;220','2:402;407;413;409;410;415');
INSERT INTO "proficiency" ("pID","pName") VALUES (401,'Acrobaties'),
 (402,'Arcanes'),
 (403,'Athlétisme'),
 (404,'Discrétion'),
 (405,'Dressage'),
 (406,'Escamotage'),
 (407,'Histoire'),
 (408,'Intimidation'),
 (409,'Investigation'),
 (410,'Médecine'),
 (411,'Nature'),
 (412,'Perception'),
 (413,'Perspicacité'),
 (414,'Persuasion'),
 (415,'Religion'),
 (416,'Représentation'),
 (417,'Supercherie'),
 (418,'Survie');
COMMIT;
