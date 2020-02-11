export const getJwt = () => {
    let token = localStorage.getItem('secret');
    return token;
}