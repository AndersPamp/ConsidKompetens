import { Register } from  '../../../Controllers/RegisterController.cs';
import jwt from '../Helper/jwt';

export const createUser = async (registerModel: Register) => {
    try {
        let options: any = {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(registerModel)
        };
        let response = await fetch('api/register/post', options);
        if(response.created) {
            let data = await response.json();
            localStorage.setItem('secret', data.jwt);
            return data;
        }else {
            return null;
        }
    }catch (err) {
        console.log(err);
    }
}