// import React, {useContext, createContext} from 'react';

// export const AuthContext = createContext();

// export function UseAuth() {
//     return useContext(AuthContext);
// }

import React, {createContext} from 'react';

export const AuthContext = createContext();

const AuthContextProvider = ({children}) => {

    
    return(
        <AuthContext.Provider>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContextProvider;