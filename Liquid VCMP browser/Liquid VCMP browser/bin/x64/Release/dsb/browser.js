function internationalize(favorites, official, normal)
{
    if (document.getElementById("favorites") != null) document.getElementById("favorites").innerText = favorites;
    if (document.getElementById("official") != null) document.getElementById("official").innerText = official;
    if (document.getElementById("normal") != null) document.getElementById("normal").innerText = normal;
}
