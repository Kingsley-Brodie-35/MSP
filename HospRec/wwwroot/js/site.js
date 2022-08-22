// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
const month = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
const d = new Date();
// Change between Calander Modes
document.getElementById("calander-choice").addEventListener("click", () => {
    let choice = document.getElementById("calander-choice").value;
    let context = document.getElementById("calander-context");
    if (choice == 0)
        context.textContent = month[d.getMonth()];

    if (choice == 1)
        context.textContent = d.Week;

    if (choice == 2)
        context.textContent = d.Month;
});

var calanderInit = () => {
    document.getElementById("calander-choice").value = 0;
    document.getElementById("calander-context").textContent = month[d.getMonth()];
};

// Initialize elements
window.addEventListener('load', (event) => {
  // Calander
  if (window.location.href.indexOf("/calander") > -1) {
    calanderInit();
  }
});

