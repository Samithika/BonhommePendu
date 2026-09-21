using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            GuessedLetterEvent guessedLetterEvent = new GuessedLetterEvent(gameData, letter);
            Events = new List<GameEvent> {
                guessedLetterEvent
            };

            // Chercher la lettre dans le mot et retourner WrongGuessEvent si celle-ci n'est pas présente
            bool letterIsPresent = false;

            for (int i = 0; i < gameData.Word.Length; i++)
            {
                if (gameData.HasSameLetterAtIndex(letter, i))
                {
                    letterIsPresent = true;
                    Events.Add(new RevealLetterEvent(gameData, letter, i));
                }
            }

            if (!letterIsPresent)
            {
                Events.Add(new WrongGuessEvent(gameData));
            }
        }
    }
}
