// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    const loginForm = document.getElementById('login-form');
    const registerForm = document.getElementById('register-form');

        document.getElementById('show-login').addEventListener('click', (e) => {
        e.preventDefault();
    registerForm.style.display = 'none';
    loginForm.style.display = 'block';
        });

        document.getElementById('show-register').addEventListener('click', (e) => {
        e.preventDefault();
    loginForm.style.display = 'none';
    registerForm.style.display = 'block';
        });

