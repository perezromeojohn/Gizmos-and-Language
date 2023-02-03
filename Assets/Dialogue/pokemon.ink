INCLUDE globals.ink

{ pokemon_name == "": -> main | -> already_chose }

=== main ===
Hi, Rumyooo! #speaker:Lovelyn #portrait:lovelyn
Hello, Lovelyn! #speaker:Rumyooo #portrait:rumyooo
-> options

=== options ===
Which <b><color=\#5B81FF>pokemon</color></b> do you choose? #speaker:Lovelyn #portrait:lovelyn
    + [Charmander]
        -> chosen("Charmander")
    + [Bulbasaur]
        -> chosen("Bulbasaur")
    + [End the Conversation]
        -> endingpart
        
=== chosen(pokemon) ===
~ pokemon_name = pokemon
You chose {pokemon}!
-> options

=== endingpart ===
Oh Okay then! I'll see you around bb! #speaker:Lovelyn #portrait:lovelyn
-> END

=== already_chose ===
You already chose {pokemon_name}
-> END