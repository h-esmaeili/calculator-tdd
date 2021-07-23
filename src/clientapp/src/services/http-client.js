import axios from "axios";


const service = axios.create({
    baseURL: "https://localhost:44344",//process.env.VUE_APP_BASE_API, // api base_url
    timeout: 50000, // timeout,
    headers: { 'Access-Control-Allow-Origin': '*' },
});

const err = (error) => {
    const { data } = error.response
    const { errors } = data
    let message = []
    for (let field in errors) {
      message.push(errors[field])
    }
    
    return Promise.reject(error)
  }
  
  // request interceptor
  service.interceptors.request.use((config) => {
    config.headers['Access-Control-Allow-Origin'] = '*'
    config.headers['Content-Type'] = 'application/json'
  
    return config
  }, err)

  export default service