(function () {
    function setTheme(theme) {
        document.documentElement.setAttribute('data-theme', theme);
        localStorage.setItem('theme', theme);
    }

    function toggleTheme() {
        const currentTheme = document.documentElement.getAttribute('data-theme');
        const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
        setTheme(newTheme);
    }

    function initTheme() {
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme) {
            setTheme(savedTheme);
        } else {
            setTheme('light'); // Default theme
        }
    }

    // Expose the toggleTheme function globally
    window.toggleTheme = toggleTheme;

    // Initialize theme on page load
    document.addEventListener('DOMContentLoaded', initTheme);
})();