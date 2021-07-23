import httpClient from './http-client';


// actions
const actions = {
    add(data) {
      return httpClient({
        url: `/api/Add`,
        method: 'post',
        data: data,
      }).then((resp) => {
        return resp
      })
    },
    subtract(data) {
      return httpClient({
        url: `/api/Subtract`,
        method: 'post',
        data: data,
      }).then((resp) => {
        return resp
      })
    },
    
  }
  
  export default {
    actions,
  }
  