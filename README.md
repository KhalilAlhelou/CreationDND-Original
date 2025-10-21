# 🧙‍♂️ CreationDND  
Application de gestion et de création de personnages pour **Donjons & Dragons (D&D)**  
Projet développé en **C# / WPF (.NET)** dans un contexte académique.

---

## 🧩 Contexte du projet  
Ce projet a été réalisé dans le cadre d’un cours de développement en C# afin de mettre en pratique la conception d’interfaces graphiques (XAML), la gestion de données complexes et la génération de documents.  
L’objectif était de fournir un outil complet pour créer, modifier et visualiser des personnages de D&D, incluant leurs compétences, statistiques, races et équipements.

---

## 👨‍💻 Fonctionnalités principales  

- 🧾 **Création de personnages personnalisés** (races, classes, statistiques, équipements)  
- 🪄 **Interface graphique interactive** développée avec **WPF (XAML + C#)**  
- 🧮 **Calcul automatique des statistiques** selon les compétences choisies  
- 🧰 **Gestion des équipements et compétences** avec menus dynamiques  
- 🖨️ **Prévisualisation et exportation en PDF** des fiches de personnages  
- 💾 **Sauvegarde et chargement en XML** pour conserver les personnages  
- 🎨 **Personnalisation de l’apparence de l’interface** (polices, boutons, couleurs)

---

## ⚙️ Architecture et technologies utilisées  

|         Composant          |          Description         |
|----------------------------|------------------------------|
|      **Langage**           |      C# (.NET Framework)     |
| **Interface graphique**    |        WPF (XAML)            |
| **Structure du projet**    | Fichiers `.xaml` et `.xaml.cs` pour la logique et la vue |
| **Exportation PDF**        | Génération automatique via bibliothèque PDF |
| **Sauvegarde des données** |             Format XML       |
| **IDE utilisé**            |         Visual Studio        |

---

## 🧱 Structure du projet  

Les principaux fichiers :  
- `MainWindow.xaml` : fenêtre principale et navigation  
- `InterfacePersonnages.xaml` : création et édition des personnages  
- `InterfaceClasses.xaml`, `InterfaceRaces.xaml`, `InterfaceStats.xaml` : gestion des attributs et statistiques  
- `InterfaceEquipements.xaml` : gestion des équipements disponibles  
- `InterfaceChoisirCompetence.xaml` : sélection des compétences  
- `App.xaml` : configuration globale et style de l’application  
- `CreationDND.csproj` : configuration du projet Visual Studio  

---

## 💡 Rôle et contribution personnelle  

**Rôle : Développeur principal – conception et implémentation de l’interface et des fonctionnalités.**  
- Conception des interfaces XAML (navigation entre fenêtres, styles, boutons dynamiques).  
- Développement de la logique en C# (gestion des personnages, calculs, statistiques).  
- Intégration du module de **prévisualisation PDF** et de **sauvegarde XML**.  
- Tests unitaires et correction des bugs liés aux interfaces et à la persistance des données.  
- Collaboration avec les membres de l’équipe pour l’intégration finale et la validation du projet.

---
