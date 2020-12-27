# Christmas Havoc

Zoals elk jaar plaatsen we een kerstboom in ons huis.  

Deze kerstboom wordt versierd met volgende zaken : 
  * kerstballen (christmasbaubles) : we hangen 20 tot 50 kerstballen in onze boom (willekeurig gekozen).  De toestand van een kerstbal is binair : ofwel is hij gebroken ofwel is hij niet gebroken.  Uiteraard is er geen enkele kerstbal gebroken wanneer wij onze boom versieren.
  * kerstkoekjes (christmascookies) : we versieren onze boom ook met 20 tot 30 koekjes (willekeurig gekozen).  Een koekje kan je opeten.  Een koekje waar een stuk van afgebeten is, blijft een koekje.  Pas wanneer het volledige koekje is opgegeten is er geen koekje meer (logisch).
  * kerstlichtjes (christmaslights) : we versieren onze boom tenslotte met 1 tot 3 kettingen met kerstlichtjes.  Elke ketting heeft 100 lichtjes.  In het begin branden ze alle 100 maar over tijd kunnen er uiteraard lichtjes uitvallen.

In ons huis loopt er echter een kwajongen (bad boy) rond die van zodra we de kamer eventjes verlaten de kerstboom aanvalt.  Soms brengt onze kwajongen ook de kwajongen van de buren mee en vallen ze gezamelijk onze kerstboom aan.  
Naast onze kwajongen(s) hebben we ook een kat die verlust op de koekjes in de kerstboom.  Ook onze kat heeft een vriendje bij de buren die hij soms meen in huis brengt.

Samengevat : er kunnen dus in huis 1 of 2 kwajongens zijn, en 1 of 2 katten.

Van zodra wij dus de kamer verlaten vallen kwajongen(s) en kat(ten) onze boom aan.  De schade die ze kunnen aanrichten is als volgt : 
  * een kwajongen : 
    * kan stukken van de koekjes bijten.  De kwajongen bestudeert elk koekje en beslist of hij er al dan niet een hapje van gaat nemen.  Sommige koekjes laat hij met rust, van andere koekjes bij hij een stuk af.  Het stuk die afgebeten wordt is steeds tussen de 10 en de 50% van het koekje.  De kans dat hij in een koekje gaat bijten is 1 op 2.
    * probeert alle kerstballen te breken.  De kans dat een kerstbal gebroken wordt is 1 op 2.
    * probeert de lichtjes in de kerboom te vernielen.  Telkens hij de kans krijgt vernietigd hij 10 tot 20% van de lichtjes in elke ketting.
  * een kat : elke kat probeert op dezelfde manier als de kwajongen koekjes op te eten (dus van sommmige koekjes eet hij 10 tot 50% op).  In zijn poging om de koekjes op te eten breekt hij natuurlijk ook kerstballen, op dezelfde manier als een kwajongen (dus ook hier een kans van 1 op 2 dat elke kerstbal gebroken wordt).  De kat kan gelukkig geen kerslichtjes stuk maken.
  

Telkens je in het programma op de knop "btnReleaseHavoc" klikt laat je de kwajongen(s) en de kat(ten) los op de boom.  
Je zorgt er dan voor dat per kerstbal, koekje en ketting met kertlichtjes getoond wordt in welke situatie ze zich bevinden (zie demo).  Je toont eveneens een inventaris van wat er gebroken of opgegeten is en wat er eventueel nog overblijft.   
Wanneer alle gebroken en opgegeten is stopt kerstdag voor ons.  

## Opbouw :  

  * Interface IBreakable : deze interface beschrijft 1 void methode TryToBreak die geen argumenten ontvangt.  
  * Interface IEatable : deze interface beschrijft 1 void methode TryToEat die geen argumenten ontvangt.  
    
  * Class ChristmasDecoration : dit is een basisklasse waarvan we in onze WPF geen instantie mogen kunnen maken.  
    Deze klasse heeft 2 fullprops : int Health en string Name  
    Deze klasse heeft 1 argumentloze constructor die de health op 100 instelt.  
      
  * Class ChristmasBauble : erft over van ChristmasDecoration en implementeert IBreakbable  
    In de argumentloze constructor van deze klasse wordt de Name prop gevuld.  De naam bestaat uit "Bauble nr " + een volgnummer die voor elke bal verschillend is.   
    Wanneer de TryToBreak methode wordt uitgevoerd ga je random bepalen of de bal al dan niet gebroken wordt.  Wordt de bal gebroken, dan krijgt de Health eigenschap de waarde 0.  
    De klasse overschrijft de ToString methode en toont de naam van de bal en de melding "I'm broken" indien de bal gebroken is of "not broken yet" indien de bal nog niet gebroken is.  
  * Class ChristmasCookie : erft over van ChristmasDecoration en implementeert IEatable  
    In de argumentloze constructor van deze klasse wordt de Name prop gevuld.  De naam bestaat uit "Cookie nr " + een volgnummer die voor elk koekje verschillend is.    
    Wanneer de TryToEat methode wordt uitgevoerd ga je random bepalen of er aan het koekje geknabbeld zal worden.  Is dat zo, dan bepaal je random hoeveel er van het koekje opgegeten wordt : deze waarde ligt gaat van 10 tot en met 50.  Je vermindert uiteraard de eigenschap Health hiermee.  Zorg er uiteraard voor dat de Health niet kleiner kan worden dan 0.  
    De klasse overschrijft de ToString methode en toont de naam van het koekje en de melding "...% remaining" waarbij "..." uiteraard staat voor de Health (of resterende gedeelte) van het koekje.  
  * Class ChristmasLights : erft over van ChristmasDecoration en implementeert IBreakbable   
    In de argumentloze constructor van deze klasse wordt de Name prop gevuld.  De naam bestaat uit "Christmaslights nr " + een volgnummer die voor elke ketting verschillend is.   
    Wanneer de TryToBreak methode wordt uitgevoerd ga je random bepalen hoeveel lichtjes er in de ketting gebroken worden.  Dit is een waarde van 10 tot en met 20.  Uiteraard ga je ook hier de Health prop verminderen en zorg je er voor dat deze niet kleiner kan worden dan 0.
    De klasse overschrijft de ToString methode en toont de naam van de ketting en de melding "... lights still burning" waarbij "..." uiteraard staat voor de Health (of resterende lichtjes) van het ketting.  
    

  * Class ChristmasService.  Deze service klasse bevat alle logica van onze "Christmas Havoc" (kerstdag ravage).  
    Deze klasse heeft 2 props :  
     * List<ChristmasDecoreation> ChristmasDecorations   
       Deze list zal alle versieringen (ballen, koekjes en lichtjes) bevatten die in de constructor zullen worden aangemaakt.  
     * bool IsChristmasDone  
       Deze prop wordt in de constructor op false gezet en zal pas op true worden gezet wanneer alles vernietigd of opgegeten werd.   
 
    In de constructor bepaal je of maak je volgende zaken aan :   
     * Hoeveel kwajongens zijn er (1 of 2)  
     * Hoeveel katten zijn er (1 of 2)  
     * Hoeveel kerstballen zijn er (20 tot en met 50)  
     * Hoeveel kerstkoekjes zijn er (20 tot en met 30)  
     * Hoeveel lichtslingers zijn er (1 tot en met 3)  
     
    De klasse heeft de void methode ReleaseHavoc (geen argumenten).  
    Wanneer deze methode wordt uitgevoerd gan je voor elke kawjonen en voor elke kat alle kertversieringen langs en laat je hun gang gaan op elk van deze.  
    
    De klasse heeft de string methode GetReport (geen argumenten).  
    In deze methode worden alle kerstversieringen overlopen en wordt de stand van zaken geretourneerd (zie demo : de retourwaarde wordt in de textblock geplaatst).  
    Als er in deze methode wordt vastgesteld dat alle koekjes opgegeten zijn en alles gebroken is, wordt de prop IsChristmasDone op true ingesteld.  
    
    De klasse heeft tenslotte nog 3 methoden GetChristmasBaubles(), GetChristmasCookies() en GetChristmasLights() die elk een List van ChristmasDecoration retourneren die respectievelijk gevuld worden met enkel ChristmasBaubles, ChristmasCookies of ChristmasLights (deze zal je nodig hebben bij de radio buttons in je WPF).
    
    

