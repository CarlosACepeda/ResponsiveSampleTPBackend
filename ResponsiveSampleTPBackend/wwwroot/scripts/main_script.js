//Author: github: CarlosACepeda <carlosalt5126@hotmail.es>

console.log("I'm alive!");

function toggleMenu()
{
    const menu = document.getElementById("menu");
    if (menu.style.display && menu.style.display !== "none" ) {
        menu.style.display = "none";
      } else {
        menu.style.display = "block";
      }
}

function handleWhenInBigScreen(e)
{
    if(e.matches)
    {
        const menu = document.getElementById("menu");
        menu.style.display = "block";
        menu.style.marginTop= ""; //Removing margin because at this point the hamburguer icon is not longer present.

        const hamburguer = document.getElementById("toggle_menu");
        hamburguer.style.display= "none";
    }
}
function handleWhenInSmallScreen(e)
{
    if(e.matches)
    {
        const menu = document.getElementById("menu");
        menu.style.display = "none";
        menu.style.marginTop= "30%"; //Added because if not, causes the menu to overlap the hamburguer icon.

        const hamburguer = document.getElementById("toggle_menu");
        hamburguer.style.display= "block";
    }
}


var toggle_menu= document.getElementById("toggle_menu");
toggle_menu.onclick= toggleMenu;


//This section is for the hamburguer menu to work correctly.

const bigScreenMediaQuery = window.matchMedia('(min-width: 701px)')
bigScreenMediaQuery.addListener(handleWhenInBigScreen)



const smallScreenMediaQuery = window.matchMedia('(max-width: 700px)');
smallScreenMediaQuery.addListener(handleWhenInSmallScreen);

// Initial check
handleWhenInSmallScreen(smallScreenMediaQuery);
handleWhenInBigScreen(bigScreenMediaQuery);


