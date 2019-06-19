import {
  compose,
  filter,
  map,
  prop,
  complement,
  isNil,
  converge,
  assoc,
  identity,
} from 'ramda';
import { transfromNested } from '../../utilities';

const isNotNill = complement(isNil);

const withParentIdFilter = f => filter(compose(f, prop('parentId')));

const extractCategoryIdsByFilter = f => compose(
  map(prop('id')),
  f,
  map(prop('category')),
  prop('imageCategories'),
);

export const getImageCategoryIds = extractCategoryIdsByFilter(withParentIdFilter(isNil));

export const getImageSubcategoryIds = extractCategoryIdsByFilter(withParentIdFilter(isNotNill));

export const assignCategoryIds = compose(
  converge(assoc('subCategoryIds'), [getImageSubcategoryIds, identity]),
  converge(assoc('categoryIds'), [getImageCategoryIds, identity]),
);

export const transformData = transfromNested(['data']);

export const assignImagesCategoryIds = map(assignCategoryIds);
