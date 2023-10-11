var bsNav;

function toggleNav(state) {
    console.log("toggleNav");
    if (state) {
        bsNav.show();
        return;
    }

    bsNav.hide();
}

var myCarousel;
var carousel;

function initializeNav() {
    bsNav = new bootstrap.Collapse(document.getElementById("navbarNav"), {
        toggle: false
    });

}

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

async function isMenuToggable() {
    return window.innerWidth < 767.98;
}

