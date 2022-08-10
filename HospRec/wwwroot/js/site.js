// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function clearDropdown() {
  var dropdowns = document.getElementsByClassName("dropdown-content");
      
  for (i = 0; i < dropdowns.length; i++) {
    var openDropdown = dropdowns[i];
    if (openDropdown.classList.contains('show')) {
      openDropdown.classList.remove('show');
    }
  }
}
window.onclick = function(event) {
  if (event.target.matches('.dropbtn')) {
    clearDropdown(); // clear existing dropdowns on screen
    if (event.target.matches('.search')) {
      document.getElementById("dropdown-search").classList.toggle("show");
    }
    if (event.target.matches('.add')) {
      document.getElementById("dropdown-add").classList.toggle("show");
    }
  } else {
    clearDropdown();
  }
}
