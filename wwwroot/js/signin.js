const toggleForm = document.querySelector('.toggle-button');
const loginForm = document.querySelector('.form-login');
const cadastroForm = document.querySelector('.form-cadastro');

localStorage.setItem('isFormActive', 'cadastro');

const showLoginForm = () => {

    cadastroForm.classList.remove('form-active');
    cadastroForm.classList.add('form-inactive');

    loginForm.classList.remove('form-inactive');
    loginForm.classList.add('form-active');

    localStorage.setItem('isFormActive', 'login');
}

const showCadastroForm = () => {
    
    loginForm.classList.remove('form-active');
    loginForm.classList.add('form-inactive');

    cadastroForm.classList.remove('form-inactive');
    cadastroForm.classList.add('form-active');

    localStorage.setItem('isFormActive', 'cadastro');
}

toggleForm.addEventListener('click', () => {

    if(localStorage.getItem('isFormActive') === 'login'){
        showCadastroForm();
        toggleForm.textContent = 'Já possui conta? Entrar.'
    }
    else{
        showLoginForm();
        toggleForm.textContent = 'Ainda não possui conta? Criar.'
    }
});