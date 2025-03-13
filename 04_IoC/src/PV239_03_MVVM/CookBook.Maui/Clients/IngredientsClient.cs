using CookBook.Maui.Clients.Interfaces;
using CookBook.Maui.Models;

namespace CookBook.Maui.Clients;

public class IngredientsClient : IIngredientsClient
{
    private List<IngredientDetailModel> items =
    [
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Vejce",
            Description = "Základní význam vajec domácí drůbeže je v první řadě biologický, tj. zajistit reprodukci daného druhu. Protože k vývoji nového jedince dochází mimo tělo matky, obsahuje vejce všechny důležité výživné složky nezbytné pro vývoj nového organismu. Zatímco vejce krůt, kachen a hus jsou produkována hlavně pro účely reprodukční, tj. slouží jako vejce násadová, slepičí vejce slouží také jako vejce konzumní a mohou být součástí lidské výživy. Vejce mají vysoký obsah plnohodnotných bílkovin (obsahují všechny aminokyseliny pro člověka nezbytné a to v poměru, který je nejpříznivější ze všech běžných potravin). Vejce dále obsahují tuky, vitamíny a minerální látky. Avšak obsahují i vysoké množství cholesterolu, takže konzumace 3 a více vajec denně prokazatelně zvyšuje riziko onemocnění a smrti.[1]",
            ImageUrl = "https://i.ibb.co/d7mZWGN/image.jpg"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Cibule",
            Description = "Jedná se o dvouletou až vytrvalou (spíše jen teoreticky[zdroj\u2060?!]) rostlinu, na bázi s velkou cibulí. Stonek je dosti robustní, dole až 3 cm v průměru, je dutý. Listy jsou jednoduché, přisedlé, s listovými pochvami. Čepele jsou celokrajné, polooblé se souběžnou žilnatinou. Květy jsou oboupohlavní, ve vrcholovém květenství, jedná se o hlávkovitě stažený zdánlivý okolík, ve skutečnosti to je stažené vrcholičnaté květenství zvané šroubel. Květenství je podepřeno toulcem. Pacibulky jsou v květenství přítomny jen někdy. Okvětí se skládá ze 6 okvětních lístků bílé až narůžovělé barvy, se středním zeleným pruhem. Tyčinek je 6. Gyneceum je složeno ze 3 plodolistů, je synkarpní, semeník je svrchní. Plodem je tobolka.",
            ImageUrl = "https://i.ibb.co/sbXC0rS/480px-Onion-on-White.jpg"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Slanina",
            Description = "Slanina nebo také špek je označení pro solené či uzené vepřové sádlo. Vyrábí se převážně z vepřového bůčku, kýty nebo hřbetu. Samotná slanina se vyrábí naložením do soli na několik týdnů a případně pozdějším vyuzením.\r\n\r\nVýraz se také používá jako zkrácený název pro anglickou slaninu, která kromě sádla obsahuje i maso.",
            ImageUrl = "https://i.ibb.co/KzsJwpbp/640px-Schweinebauch-1.jpg"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Rajče",
            Description = "Rajče jedlé, též lilek rajče (Solanum lycopersicum) je trvalka bylinného charakteru pěstovaná jako jednoletka. Patří do čeledi lilkovitých. Pochází ze Střední a Jižní Ameriky. Plodem je bobule zvaná rajče, původně rajské jablko, proto se rajče řadí mezi plodovou zeleninu, ale jsou spekulace o tom, že rajče je ovoce.",
            ImageUrl = "https://i.ibb.co/1TzsF6B/ingredient-7.jpg"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Mléko",
            Description = "Mléko je produkt mléčných žláz (až na výjimky) samic savců během laktace. Obsahuje bílkoviny, tuky, mléčný cukr laktózu a mnoho dalších stopových látek (vitamíny, minerály). Mléko je základním zdrojem výživy hlavně pro mláďata, která z tzv. „mleziva“ získávají potřebné protilátky a vitamíny pro upevnění své imunity. Savci konzumují mléko dokud nejsou schopni trávit pevnou stravu (píce, maso), v dospělosti zpravidla o schopnost štěpit mléčný cukr laktózu přicházejí. V lidské výživě se označením „mléko“ většinou rozumí nejčastěji konzumované kravské mléko, uplatňují se ale i jiná dobytčí mléka nebo rostlinné náhražky (rostlinné mléko). Charakteristickou bílou barvu mléka způsobuje odraz světla od malých nerozpustných kuliček tuku, které jsou v mléce rozptýleny (mléko je emulze).",
            ImageUrl = "https://i.ibb.co/BB3gVxr/ingredient-2.jpg"
        }
    ];

    public async Task<ICollection<IngredientListModel>> GetIngredientsAllAsync()
        => items
        .Select(ingredient => new IngredientListModel
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            ImageUrl = ingredient.ImageUrl
        })
        .ToList();

    public async Task<IngredientDetailModel?> GetIngredientByIdAsync(Guid id)
        => items.FirstOrDefault(ingredient => ingredient.Id == id);
}