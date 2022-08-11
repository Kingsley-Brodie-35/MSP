// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function clearClassName(targetClass, clearClass) {
  var dropdowns = document.getElementsByClassName(targetClass);
      
  for (i = 0; i < dropdowns.length; i++) {
    var openDropdown = dropdowns[i];
    if (openDropdown.classList.contains(clearClass)) {
      openDropdown.classList.remove(clearClass);
    }
  }
}
window.onclick = function(event) {
  if (event.target.matches('.dropbtn')) {
    clearClassName("dropdown-content", "show"); // clear existing dropdowns on screen
    clearClassName("dropbtn", "fix"); // clear fix colors on dropdown button
    if (event.target.matches('.search')) {
      document.getElementById("dropSearch").classList.toggle("fix");
      document.getElementById("dropdown-search").classList.toggle("show");
    }
    if (event.target.matches('.add')) {
      document.getElementById("dropAdd").classList.toggle("fix");
      document.getElementById("dropdown-add").classList.toggle("show");
    }
  } else {
    clearClassName("dropdown-content", "show");
    clearClassName("dropbtn", "fix");
  }
}
