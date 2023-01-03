-> main

=== main ===
Hi, Rumyooo! #speaker:Lovelyn #portrait:lovelyn
Hello, Lovelyn! #speaker:Rumyooo #portrait:rumyooo
Which pokemon do you choose? #speaker:Lovelyn #portrait:lovelyn
    + [Charmander]
        -> chosen("Charmander")
    + [Bulbasaur]
        -> chosen("Bulbasaur")
    + [Squirtle]
        -> chosen("Squirtle")

=== chosen(pokemon) ===
You chose {pokemon}!
-> END