import { map, join, compose } from 'ramda';

export default compose(
  join(' or '),
  map(id => `ParentId = ${id}`),
);
