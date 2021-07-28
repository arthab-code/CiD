
public class GLOBAL {


	public static int       WAVE            = 0;         /** zmienna odpowiadająca za falę **/
	public static int       SCORE           = 0;           /** zmienna odpowiadająca za liczbę punktów **/
	public static int       COINS           = 0;           /** zmienna odpowiadająca za liczbę monet **/

	public static bool      pause           = false;       /** zmienna odpowiadająca za pauzę w grze**/
	public static bool      shop_pause      = false;       /** zmienna odpowiadająca za pauzę dotyczącą sklepu **/
	public static bool      gameover_pause  = false;
	public static bool      bonus_pause     = false;

	public static int       enemies         = 5;           /** zmienna odpowiadająca za liczbę przeciwników w danej fali **/
	public static int       bufor_enemies   = 0;

	public static float     divisionSpeed   = 500f;        /** zmienna odpowiadająca za dzielenie w przypadku obliczeń statystyk szybkości **/

	public static float     divisionHp      = 5f;        /** zmienna odpowiadająca za dzielenie w przypadku obliczeń statystyk HP **/

	public static float     divisionTime    = 50f;        /** zmienna odpowiadająca za dzielenie w przypadku obliczeń czasu respawnu **/

	public static float     spawnDelay      = 2.3f;         /** Zmienna rpzechowująca wartość początkową opoźnienia w respawnie **/

	public static float      gameplayTime    = 0f;

	public static float  actualGameplayTime = 0f;

	public static float     gameplayTimeMax = 600f;

	public static int       tutorial        = 1;

	public static bool      tutorial_end    = false;

	public static bool      tutorial_pause = true;

	public static byte      tutorial_count = 0;

	public static bool      exit_pause     = false;

	public static bool      wave_pause     = false;

	public static bool      wave_check     = false;

	public static bool      mute           = false;

	public static bool      boss_active     = false;
	public static int       boss_type      = 0;
}
