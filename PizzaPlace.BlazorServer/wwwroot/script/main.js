
var bsNav;

function toggleNav(state) {

    if (bsNav === undefined)
        bsNav = new bootstrap.Collapse(document.getElementById("navbarNav"));

    if (state)
    {
        bsNav.show();
        return;
    }

    bsNav.hide();
}