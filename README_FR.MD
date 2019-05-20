# Auteurs

Workshop en C# réalisé par Louis Cantinieaux & Thibaut Janssens.

# Theorie

[Slides](https://docs.google.com/presentation/d/1jYp38dPLZ4UNBnItOynNL402H8gap3mblmcZNIKusL4/edit?usp=sharing) de la présentation.
Vous pouvez aussi trouver dans le répertoire un document word reprenant une partie de la théorie.

# Environement

Pour developper en C# avec linux, vous pouvez lancer le script `./install.sh` pour télécharger et installer Monodevelop.

Si vous ne pouvez le lancer, faites la commande suivante dans votre terminal :

```cmd
chmod +x ./install.sh
./install.sh
``` 

# Exercices

### Exercice 1

Demander à l'utilisateur d'entrer 3 nombres: min, max, et current. Afficher si le nombre 'current' est compris entre le min et le max.

Bonus: Si le min est supérieur au max, afficher un message d'erreur pour expliquer à l'utilisateur qu'il peut retourner à l'école primaire et quitter le programme.

### Exercice 2

Afficher tout les nombres **pairs** entre 1 et 100 compris.
Faites l'exercices 2 fois. La première fois avec une boucle while, la seconde fois avec une boucle for.

### Exercice 3

Faites un tableau avec différents nombres à l'intérieur.
Renvoyez la somme, la moyenne, le minimum et le maximum contenu dans ce tableau.

### Exercice 4

Choississez une version du 2e exercice et changeons le un petit peu.
Si le nombre est un multiple de 5, afficher à la place "Ding Ding"
Si le nombre est un multiple de 7, afficher à la place "Bottle".
Si le nombre est un multiple des deux, afficher à la place "Ding Ding Bottle".

### Exercice 5

Corsons un petit peu les choses.

![spice](./spicy.gif)

Nous allons faire le jeu du nombre magique.  
L'ordinateur va choisir un nombre aléatoire entre 1 et 100 compris.  
Invitez l'utilisateur à entrer un nombre et dites lui si le nombre magique est plus grand ou plus petit que le sien.  
Bonus: Vous pouvez rajouter un try catch pour éviter que l'utilisateur n'entre une chaine de caractères à la place d'un nombre entier + inviter l'utilisateur à rejouer.

### Exercice 6

Trop facile? Ok essayons ça !

![oil-up](./oil-up.jpg)

Nous allons faire un jeu de guerriers. Invitez l'utilisateur à créer 3 Guerriers.

Il va affronter des monstres aléatoire (faible, fort ou boss).
S'il tue un monstre faible, il gagne 10 points.
S'il tue un monstre fort, il gagne 20 points mais il peut également avoir une chance de récupérer une potion. La potion régénère 25 points de vie.
S'il tue un boss, il gagne 100 points et s'il avait un guerrier mort il peut le faire revivre. Sinon il récupère 2 potions.
Si un guerrier meurt, l'utilisateur utilisera le guerrier suivant dans sa liste. S'il n'en a plus, il perd.
Afficher le score à la fin de la partie et proposez à l'utilisateur de rejouer.

Le guerrier est un objet qui possède plusieurs propriétés comme un nom, 100 points de vie, et lorsqu'il tapera, il fera un nombre de dégats aléatoire entre 0-10. (0 il rate, 10 coup critique)
Le monstre faible est un object qui possède 50 points de vie, et des dégats aléatoire entre 0 et 3.
Le monstre fort a 100 points de vie, et des nombres de dégats aléatoire entre 0 et 5.
Le boss quand à lui possède 150 points de vie, et des dégats aléatoire entre 0 et 7.