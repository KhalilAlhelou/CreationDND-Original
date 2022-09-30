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
	"descC"	TEXT,
	"hitPointC"	INTEGER,
	"isSpellcaster"	INTEGER,
	"bProfficiency"	INTEGER,
	"listAttrs"	TEXT,
	PRIMARY KEY("idC")
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
 (206,'Druidique','Vous connaissez le druidique, le langage secret des druides. Vous pouvez parler cette langue et l''utiliser pour laisser des messages cachés. Vous et les autres personnes qui connaissent cette langue repèrent automatiquement un tel message. Les autres repèrent la présence du message en réussissant un test de Sagesse (Perception) DC 15, mais ne peuvent pas le déchiffrer sans magie.');
INSERT INTO "race" ("idR","nameR","descR","bForceR","bDexR","bConstR","bIntR","bSageR","bCharR") VALUES (110,'Sangdragon','Les Draconiques ressemblent beaucoup à des dragons se tenant debout sous une forme humanoïde, bien qu''ils n''aient ni ailes ni queue.',2,0,0,0,0,1),
 (120,'Nain de colline','Audacieux et robustes, les nains sont connus pour être d''habiles guerriers, mineurs et travailleurs de la pierre et du métal.\r\n\r\nEn tant que nain des collines, vous avez des sens aiguisés, une profonde intuition et une remarquable résilience. Les nains d''or de Faerûn dans leur puissant royaume du sud sont des nains des collines, tout comme les Neidar exilés et les Klar avilis de Krynn dans le cadre de Dragonlance.',0,0,2,0,1,0),
 (121,'Nain de montagne','Audacieux et robustes, les nains sont connus pour être d''habiles guerriers, mineurs et travailleurs de la pierre et du métal.\r\n\r\nEn tant que nain des montagnes, vous êtes fort et robuste, habitué à une vie difficile en terrain accidenté. Vous êtes probablement de grande taille (pour un nain) et avez tendance à avoir une couleur plus claire. Les nains de bouclier du nord de Faerûn, ainsi que le clan Hylar au pouvoir et le noble clan Daewar de Dragonlance, sont des nains des montagnes.',2,0,2,0,0,0),
 (130,'Haut elfe','Les eladrins sont un peuple magique d''une grâce surnaturelle, vivant dans le monde mais n''en faisant pas entièrement partie.\r\n\r\nEn tant que haut elfe, vous avez un esprit vif et vous maîtrisez au moins les bases de la magie. Dans de nombreux mondes de D&D, il existe deux types de hauts elfes. Le premier type (qui comprend les elfes gris et les elfes des vallées de Greyhawk, les Silvanesti de Dragonlance, et les elfes du soleil des Royaumes oubliés) est hautain et reclus, et se croit supérieur aux non-elfes et même aux autres elfes. L''autre type (y compris les hauts elfes de Greyhawk, les Qualinesti de Dragonlance et les elfes de la lune des royaumes oubliés) est plus commun et plus amical, et on le rencontre souvent parmi les humains et les autres races.\r\n\r\nLes elfes du soleil de Faerûn (également appelés elfes d''or ou elfes du soleil levant) ont une peau de bronze et des cheveux cuivrés, noirs ou blond doré. Leurs yeux sont dorés, argentés ou noirs. Les elfes de la lune (également appelés elfes d''argent ou elfes gris) sont beaucoup plus pâles, avec une peau d''albâtre parfois teintée de bleu. Leurs cheveux sont souvent blancs argentés, noirs ou bleus, mais il n''est pas rare qu''ils soient blonds, bruns ou roux. Leurs yeux sont bleus ou verts et mouchetés d''or.',0,2,0,1,0,0),
 (131,'Elfe sylvestre','Les eladrins sont un peuple magique d''une grâce surnaturelle, vivant dans le monde mais n''en faisant pas entièrement partie.\r\n\r\nEn tant qu''elfe des bois, vous avez des sens aiguisés et de l''intuition, et vos pieds légers vous portent rapidement et furtivement dans vos forêts natales. Cette catégorie comprend les elfes sauvages (grugach) de Greyhawk et les Kagonesti de Dragonlance, ainsi que les races appelées elfes des bois dans Greyhawk et les Royaumes oubliés. À Faerûn, les elfes des bois (également appelés elfes sauvages, elfes verts ou elfes des forêts) sont reclus et se méfient des non-elfes.\r\n\r\nLa peau des elfes des bois a tendance à être de couleur cuivrée, avec parfois des traces de vert. Leurs cheveux sont plutôt bruns et noirs, mais ils sont parfois blonds ou cuivrés. Leurs yeux sont verts, bruns ou noisette.',0,2,0,0,1,0),
 (132,'Elfe noir','Les eladrins sont un peuple magique d''une grâce surnaturelle, vivant dans le monde mais n''en faisant pas entièrement partie.\r\n\r\nCette version de l''eladrin est apparue à l''origine dans le Guide du Maître du Donjon comme un exemple pour créer vos propres sous-races.\r\n\r\nCréatures magiques fortement liées à la nature, les eladrins vivent dans le royaume crépusculaire de la Féerie. Leurs villes traversent parfois le plan matériel, apparaissant brièvement dans des vallées montagneuses ou des clairières de forêts profondes avant de disparaître dans le monde féerique.',0,2,0,0,0,1),
 (140,'Demi-elfe','Les demi-elfes combinent ce que certains appellent les meilleures qualités de leurs parents elfes et humains.',0,0,0,0,0,2),
 (150,'Demi-orc','Certains demi-orques s''élèvent pour devenir de fiers leaders de communautés orques. D''autres s''aventurent dans le monde pour prouver leur valeur. Beaucoup d''entre eux deviennent des aventuriers, atteignant la grandeur grâce à leurs exploits.',2,0,1,0,0,0),
 (160,'Halfelin aux pieds légers','Les halflings de petite taille survivent dans un monde rempli de créatures plus grandes en évitant de se faire remarquer ou, à défaut, en évitant de se faire attaquer.\r\n\r\nEn tant que halfling aux pieds légers, vous pouvez facilement vous cacher, même en utilisant d''autres personnes comme couverture. Vous avez tendance à être affable et à bien vous entendre avec les autres. Dans les Royaumes Oubliés, les halflings aux pieds clairs se sont répandus le plus loin et sont donc la variété la plus commune.\r\n\r\nLes pieds-légers sont plus enclins à l''errance que les autres halflings, et s''installent souvent aux côtés d''autres races ou adoptent une vie nomade. Dans le monde de Greyhawk, on appelle ces halflings des pieds de poils ou des tallfellows.',0,2,0,0,0,1),
 (161,'Halfelin Robuste','Les halflings de petite taille survivent dans un monde rempli de créatures plus grandes en évitant de se faire remarquer ou, à défaut, en évitant de se faire attaquer.\r\n\r\nEn tant que halfling corpulent, vous êtes plus résistant que la moyenne et vous avez une certaine résistance au poison. Certains disent que les stouts ont du sang nain. Dans les Royaumes oubliés, on appelle ces halflings des cœurs forts, et ils sont plus courants dans le sud.',0,2,1,0,0,0),
 (170,'Humain','Les humains sont les personnes les plus adaptables et les plus ambitieuses parmi les races communes. Quelle que soit leur motivation, les humains sont les innovateurs, les réalisateurs et les pionniers des mondes.',1,1,1,1,1,1),
 (180,'Gnome des roches','L''énergie et l''enthousiasme d''un gnome pour la vie transparaissent dans chaque centimètre de son petit corps.\r\n\r\nEn tant que gnome des rochers, vous avez une inventivité et une résistance naturelles supérieures à celles des autres gnomes. La plupart des gnomes des mondes de D&D sont des gnomes de roche, y compris les gnomes bricoleurs de Dragonlance.',0,0,1,2,0,0),
 (181,'Gnome de foret','L''énergie et l''enthousiasme d''un gnome pour la vie transparaissent dans chaque centimètre de son petit corps.\r\n\r\nEn tant que gnome des rochers, vous avez une inventivité et une résistance naturelles supérieures à celles des autres gnomes. La plupart des gnomes des mondes de D&D sont des gnomes de roche, y compris les gnomes bricoleurs de Dragonlance.',0,1,0,2,0,0),
 (190,'Tieffelin','Être accueilli par des regards et des chuchotements, subir la violence et les insultes dans la rue, voir la méfiance et la peur dans chaque regard : tel est le lot du tiefling.',0,0,0,1,0,2);
INSERT INTO "class" ("idC","nameC","descC","hitPointC","isSpellcaster","bProfficiency","listAttrs") VALUES (301,'Barbare','Un guerrier féroce d''origine primitive qui peut entrer dans une rage de combat.',12,0,0,'201;202'),
 (302,'Barde','Un magicien inspirant dont le pouvoir fait écho à la musique de la création',8,1,0,'203;204'),
 (303,'Clerc','Un champion sacerdotal qui manie la magie divine au service d''une puissance supérieure.',8,1,0,'203;205'),
 (304,'Druide','Un prêtre de l''Ancienne Foi, maniant les pouvoirs de la nature et adoptant des formes animales.',8,1,0,'203;206');
COMMIT;
