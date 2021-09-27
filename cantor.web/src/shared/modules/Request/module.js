const state = {
  pendingRequestCount: 0,
  isTurnedOn: true
};

const mutations = {
  incrementPendingRequestCount(state) {
    state.pendingRequestCount++;
  },
  decrementPendingRequestCount(state) {
    state.pendingRequestCount--;
  },
  turnOn(state) {
    state.isTurnedOn = true;
  },
  turnOff(state) {
    state.isTurnedOn = false;
  }
};

const getters = {
  anyPendingRequests: state => state.isTurnedOn && state.pendingRequestCount > 0
};

const module = {
  namespaced: true,
  state,
  mutations,
  getters
};

export default module;
