import request from '@/util/request'

const state = {}

// getters
const getters = {}

// actions
const actions = {
    add(context, data) {
      return request({
        url: `/api/Add`,
        method: 'post',
        data: data,
      }).then((resp) => {
        return resp
      })
    },
    subtract(context, data) {
      return request({
        url: `/api/Subtract`,
        method: 'post',
        data: data,
      }).then((resp) => {
        return resp
      })
    },
}
  
// mutations
const mutations = {}

export default {
  namespace: true,
  state,
  getters,
  actions,
  mutations,
}