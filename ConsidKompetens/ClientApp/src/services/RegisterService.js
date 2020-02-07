import { Register } from  '../../../Controllers/HomeController.cs/';

export const createUser = async (request: Register) => {
    try {
        let options: any = {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            contentType: 'application/json',
            body: JSON.stringify(request)
        };
        let response = await fetch('api/register/registerUser', options);
        if(response.ok) {
            let data = await response.json();
            return data;
        }else {
            return null;
        }
    }catch (err) {
        console.log(err);
    }
}