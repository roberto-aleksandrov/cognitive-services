import { zipObj } from 'ramda';

export const createMutations = ({ names, namespace }) => ({ commit }) => zipObj(
  names,
  names.map(n => response => commit(`${namespace}/${n}`, response, { root: true })),
);


// export const getPictureMutations = {
//   saveAll: ({ commit }) => response => commit('picture/saveAll', response, { root: true }),
//   save: ({ commit }) => response => commit('picture/save', response, { root: true }),
// };
