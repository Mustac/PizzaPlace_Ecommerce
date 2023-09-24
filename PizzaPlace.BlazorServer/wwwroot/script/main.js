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

var myCarousel;
var carousel;

function initializeCarousel() {
    myCarousel = document.getElementById("feedback-carousel");
    carousel = new bootstrap.Carousel(myCarousel, {
        interval: false,
        wrap: true,
        touch: false,
        keyboard: false,
    })
}

function caruselNext() {
    carousel.next();
}