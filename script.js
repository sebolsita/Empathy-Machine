document.addEventListener("DOMContentLoaded", function () {
    const sections = document.querySelectorAll("section");
    const navLinks = document.querySelectorAll(".nav-links a");
    const logo = document.querySelector(".logo");
    const navWrapper = document.querySelector(".nav-wrapper");
    const navLinksContainer = document.querySelector(".nav-links");
    const leftFade = document.querySelector(".nav-wrapper::before");
    const rightFade = document.querySelector(".nav-wrapper::after");

    /* Scroll to Top When Clicking Logo */
    logo.addEventListener("click", () => {
        window.scrollTo({ top: 0, behavior: "smooth" });
    });

    /* Update Navbar Active Link on Scroll */
    function updateActiveNav() {
        let scrollPosition = window.scrollY + 100;

        sections.forEach((section) => {
            const top = section.offsetTop;
            const height = section.offsetHeight;
            const id = section.getAttribute("id");

            if (scrollPosition >= top && scrollPosition < top + height) {
                navLinks.forEach((link) => {
                    link.classList.remove("active");
                    if (link.getAttribute("href") === `#${id}`) {
                        link.classList.add("active");
                    }
                });
            }
        });
    }

    /* Check If Navbar Needs Scroll Indicator */
    function updateScrollIndicators() {
        leftFade.style.opacity = navLinksContainer.scrollLeft > 0 ? "1" : "0";
        rightFade.style.opacity = navLinksContainer.scrollLeft + navLinksContainer.clientWidth < navLinksContainer.scrollWidth ? "1" : "0";
    }

    navLinksContainer.addEventListener("scroll", updateScrollIndicators);
    window.addEventListener("scroll", updateActiveNav);
    updateActiveNav();
    updateScrollIndicators();
});

