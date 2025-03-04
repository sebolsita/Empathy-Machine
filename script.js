document.addEventListener("DOMContentLoaded", function () {
    const sections = document.querySelectorAll("section");
    const navLinks = document.querySelectorAll(".nav-links a");
    const logo = document.querySelector(".logo");

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

    /* Scroll to Top When Clicking Logo */
    logo.addEventListener("click", () => {
        window.scrollTo({ top: 0, behavior: "smooth" });
    });

    /* Enable Smooth Scroll When Clicking Navbar Links */
    navLinks.forEach((anchor) => {
        anchor.addEventListener("click", function (e) {
            if (this.getAttribute("href").startsWith("#")) {
                e.preventDefault();
                const target = document.querySelector(this.getAttribute("href"));
                target.scrollIntoView({ behavior: "smooth" });
            }
        });
    });

    /* Run Active Navbar Update on Scroll */
    window.addEventListener("scroll", updateActiveNav);
    updateActiveNav(); // Run on page load
});
