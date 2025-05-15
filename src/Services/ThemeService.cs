using System;
using Microsoft.JSInterop;

namespace BlazorApp.Services
{
    public class ThemeService
    {
        private readonly IJSRuntime _jsRuntime;
        private bool _isDarkTheme;

        public event Action OnThemeChanged;

        public ThemeService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public bool IsDarkTheme => _isDarkTheme;

        public async Task ToggleThemeAsync()
        {
            _isDarkTheme = !_isDarkTheme;
            await ApplyThemeAsync();
            OnThemeChanged?.Invoke();
        }

        public async Task InitializeThemeAsync()
        {
            var storedTheme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "theme");
            _isDarkTheme = storedTheme == "dark";
            await ApplyThemeAsync();
        }

        private async Task ApplyThemeAsync()
        {
            var theme = _isDarkTheme ? "dark" : "light";
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", theme);
            await _jsRuntime.InvokeVoidAsync("document.documentElement.setAttribute", "data-theme", theme);
        }
    }
}