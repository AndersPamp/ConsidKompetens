import { Users } from '../../../../ConsidKompetens_Services/'

export const getUsers = async (request: Users) => {
    try {
        let options: any = {
            method: 'GET',
        }
    }
}

// export const getUsers = async () => {
//     try {
//         let response = await fetch('/api/login');
//         if (response.ok) {
//             let data = await response.json();
//             return data;
//         }else {
//             return null;
//         }
//     }catch (err) {
//         console.log(err);
//     }
// };